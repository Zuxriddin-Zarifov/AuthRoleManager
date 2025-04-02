
string num1 = "20+22i", num2 = "-18+-10i";
// 4 + 2i + 2i + -1

string[] nums1 = num1.Split('+');
string[] nums2 = num2.Split('+');
Console.WriteLine(nums1[0] + " " + nums1[1]);
Console.WriteLine(nums2[0] + " " + nums2[1]);
Console.WriteLine();

Console.WriteLine(kopaytma(nums1[0], nums2[0]));// a * a
Console.WriteLine(kopaytma(nums1[0], nums2[1]));// a * b
Console.WriteLine(kopaytma(nums1[1], nums2[0]));// b * a
Console.WriteLine(kopaytma(nums1[1], nums2[1]));
Console.WriteLine();

string res1 = kopaytma(nums1[0], nums2[0]) + "+" +// a * a
              kopaytma(nums1[0], nums2[1]) + "+" +// a * b
              kopaytma(nums1[1], nums2[0]) + "+" +// b * a
              kopaytma(nums1[1], nums2[1]);   // b * b
Console.WriteLine(sodda(res1));



static string sodda(string str)
{
    // 4 + 2i + 2i + -1
    string result = "";
    string[] nums = str.Split("+");
    int sum1 = (int.Parse(nums[0]) + int.Parse(nums[3]));
    string num_i1 = "", num_i2 = "", minus = "";
    string komp_num1 = nums[1];
    string komp_num2 = nums[2];
    for(int i = 0; i < komp_num1.Length;i++)
    {
        if (char.IsDigit(komp_num1[i]))
        {
            num_i1 = num_i1 + (int.Parse(minus+"1") * int.Parse(komp_num1[i].ToString())).ToString();
            minus = "";
        }
        else if (komp_num1[i] != 'i')
            minus = "-";
    }
    for(int i = 0; i < komp_num2.Length;i++)
    {
        if (char.IsDigit(komp_num2[i]))
        {
            num_i2 = num_i2 + (int.Parse(minus + "1") * int.Parse(komp_num2[i].ToString())).ToString();
            minus = "";
        }
        else if (komp_num2[i] != 'i')
            minus = "-";
    }
    int sum2 = int.Parse(num_i1) + int.Parse(num_i2);

    result = sum1.ToString() + "+" + sum2.ToString() + "i";

    return result;
}



static string kopaytma(string s1,string s2)
{
    string result = "";
    string str_i_1 = "";
    string str_i_2 = "";
    string num1 = "", num2 = "";

    for (int i = 0; i < s1.Length; i++)
    {
        if (char.IsDigit(s1[i]))
        {
            num1 += s1[i];
        }
        else if (s1[i] == '-')
            num1 += s1[i];
        else
        {
            str_i_1 += s1[i];
        }
    }
    for (int i = 0; i < s2.Length; i++)
    {
        if (char.IsDigit(s2[i]))
        {
            num2 += s2[i];
        }
        else if (s2[i] == '-')
            num2 += s2[i];
        else
        {
            str_i_2 += s2[i];
        }
    }

    int res = int.Parse(num1) * int.Parse(num2);

    if (str_i_1 == str_i_2)
    {
        if (!(str_i_1 == ""))
        {
            result = (res * (-1)).ToString();
            return result;
        }
    }
    result = res.ToString() + str_i_1 + str_i_2;
    

    return result;
}