using System.Text;


Console.WriteLine(Math.MathChallenge(35132));
Console.WriteLine(Math.MathChallenge(199));
Console.WriteLine(Math.MathChallenge(26712));



public static class Math
{
    public static string MathChallenge(int num)
    {
        int[] newNum = num.ToString().ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToArray();


        if (newNum.Length < 2)
            return "Not Possible";
        return RecursiveFunction(newNum.Skip(1).ToArray(), newNum[0]);
    }

    private static string RecursiveFunction(int[] updatedArray, int updatedSum)
    {

        if (updatedArray.Length == 1)
        {
            if (updatedSum + updatedArray[0] == 0)
            {
                return "+";
            }
            if (updatedSum - updatedArray[0] == 0)
            {
                return "-";
            }

            return "Not Possible";

        }

        string updatedString1 = RecursiveFunction(updatedArray.Skip(1).ToArray(), updatedSum - updatedArray[0]);
        if (updatedString1 != "Not Possible")
        {
            return "-" + updatedString1;
        }

        string updatedString2 = RecursiveFunction(updatedArray.Skip(1).ToArray(), updatedSum + updatedArray[0]);
        if (updatedString2 != "Not Possible")
        {
            return "+" + updatedString2;
        }

        return "Not Possible";
    }

}

