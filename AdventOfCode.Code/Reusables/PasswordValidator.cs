using System;

public class PasswordValidator
{

    public static bool IsValid(string password, string policy)
    {
        password = password.Trim();
        var policyParts = policy.Split(new char[] {' ', '-' });
        var letterCheck = policyParts[policyParts.Length - 1];

        int count = 0;

        for (var i = 0; i < policyParts.Length - 1; i++)
        {
            if (password[int.Parse(policyParts[i])-1].ToString() == letterCheck)
                count++;
            if (count > 1)
                break;
        }

        return (count == 1);
    }
}