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

    // 1. Construa a funcionalidade de cadastrar novas contas
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

    // 2. Construa a funcionalidade de fazer Login
    public void Login(int number, int agency, int pass)
    {
        throw new NotImplementedException();
    }

    // 3. Construa a funcionalidade de fazer Logout
    public void Logout()
    {
        throw new NotImplementedException();
    }

    // 4. Construa a funcionalidade de checar o saldo
    public int CheckBalance()
    {
        throw new NotImplementedException();
    }

    // 5. Construa a funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        throw new NotImplementedException();
    }

    // 6. Construa a funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        throw new NotImplementedException();
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        throw new NotImplementedException();
    }


}
