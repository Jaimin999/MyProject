using System;
using System.Text;

public class OldPhonePad
{
    private static readonly string[] BUTTONS = {
        "",    // 0
        "",    // 1
        "ABC", // 2
        "DEF", // 3
        "GHI", // 4
        "JKL", // 5
        "MNO", // 6
        "PQRS",// 7
        "TUV", // 8
        "WXYZ" // 9
    };

    public static string OldPhone(string input)
    {
        StringBuilder output = new StringBuilder();
        StringBuilder currentPress = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];
            
            if (ch == '#')
            {
                break;
            }
            else if (ch == '*')
            {
                if (output.Length > 0)
                {
                    output.Length--;
                }
                currentPress.Clear();
            }
            else if (ch == ' ')
            {
                if (currentPress.Length > 0)
                {
                    char button = currentPress[0];
                    int pressCount = currentPress.Length;
                    output.Append(GetCharacter(button, pressCount));
                    currentPress.Clear();
                }
            }
            else
            {
                if (currentPress.Length > 0 && currentPress[0] != ch)
                {
                    char button = currentPress[0];
                    int pressCount = currentPress.Length;
                    output.Append(GetCharacter(button, pressCount));
                    currentPress.Clear();
                }
                currentPress.Append(ch);
            }
        }

        if (currentPress.Length > 0)
        {
            char button = currentPress[0];
            int pressCount = currentPress.Length;
            output.Append(GetCharacter(button, pressCount));
        }

        return output.ToString();
    }

    private static char GetCharacter(char button, int pressCount)
    {
        int btn = button - '0';
        if (btn < 2 || btn > 9)
        {
            return ' ';
        }
        string letters = BUTTONS[btn];
        pressCount = (pressCount - 1) % letters.Length;
        return letters[pressCount];
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(OldPhone("33#")); // Output: E
        Console.WriteLine(OldPhone("22#")); // Output: B
        Console.WriteLine(OldPhone("4433555 555666#")); // Output: HELLO
        Console.WriteLine(OldPhone("52444644466#")); // Output: JAIMIN
    }
}