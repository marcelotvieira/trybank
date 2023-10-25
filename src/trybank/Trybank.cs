namespace Trybank.Lib;

public class TrybankLib
{
    public bool Logged;
    public int loggedUser;

    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;

    public int registeredAccounts;
    private int maxAccounts = 50;

    public TrybankLib()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    private void CheckAgencyDisponibility(int agency)
    {
        for (int a = 0; a < registeredAccounts + 1; a++)
            if (Bank[a, 1] == agency)
                throw new ArgumentException("A conta já está sendo usada!");

    }

    public struct GetAccountResult
    {
        public int[] Account;
        public int Index;
    }

    public void RegisterAccount(int number, int agency, int pass)
    {
        try
        {
            CheckAgencyDisponibility(agency);
            int[] newAccount = new int[4] { number, agency, pass, 0 };

            for (int i = 0; i < newAccount.Length; i++)
                Bank[registeredAccounts, i] = newAccount[i];
            registeredAccounts++;
        }
        catch (ArgumentException ex)
        {
            throw (ex);
        }
    }

    private void CheckLogin()
    {
        if (!Logged)
            throw new AccessViolationException("Usuário não está logado");
    }
    private void CheckIfDisponibleLogin()
    {
        if (Logged)
            throw new AccessViolationException("Usuário já está logado");
    }

    private GetAccountResult GetAccountByNumberAndAgency(int number, int agency)
    {
        for (int a = 0; a < registeredAccounts; a++)
        {
            if (Bank[a, 0] == number && Bank[a, 1] == agency)
                return new GetAccountResult
                {
                    Account = Enumerable.Range(0, 4).Select(i => Bank[a, i]).ToArray(),
                    Index = a
                };
        }
        throw new ArgumentException("Agência + Conta não encontrada");
    }

    public void Login(int number, int agency, int pass)
    {
        try
        {
            CheckIfDisponibleLogin();
            var accountResult = GetAccountByNumberAndAgency(number, agency);

            if (accountResult.Account[2] != pass)
                throw new ArgumentException("Senha incorreta");

            Logged = !Logged;
            loggedUser = accountResult.Index;
        }
        catch (ArgumentException ex)
        {
            throw (ex);
        }
        catch (AccessViolationException ex)
        {
            throw (ex);
        }

    }

    public void Logout()
    {
        CheckLogin();
        Logged = !Logged;
        loggedUser = -99;
    }

    public int CheckBalance()
    {
        CheckLogin();
        return Bank[loggedUser, 3];
    }

    public void Deposit(int value)
    {
        CheckLogin();
        Bank[loggedUser, 3] += value;
    }

    public void Withdraw(int value)
    {
        CheckLogin();
        if (Bank[loggedUser, 3] < value)
            throw new InvalidOperationException("Saldo insuficiente");
        Bank[loggedUser, 3] -= value;
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        throw new NotImplementedException();
    }


}
