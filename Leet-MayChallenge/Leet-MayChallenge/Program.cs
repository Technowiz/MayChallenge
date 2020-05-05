using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet_MayChallenge
{
    class Program
    {
        /*You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
You are given an API bool isBadVersion(version) which will return whether version is bad. Implement a function to find the first bad version. You should minimize the number of calls to the API.
Example:
Given n = 5, and version = 4 is the first bad version.

call isBadVersion(3) -> false
call isBadVersion(5) -> true
call isBadVersion(4) -> true

Then 4 is the first bad version.*/

        public bool IsBadVersion(int version)
        {
            if (version > 3)
                return true;
            return false;
        }
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid)) right = mid;
                else left = mid + 1;
            }
            return left;
        }
        /*You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
The letters in J are guaranteed distinct, and all characters in J and S are letters. Letters are case sensitive, so "a" is considered a different type of stone from "A".
Example 1:
Input: J = "aA", S = "aAAbbbb"
Output: 3*/
        public int NumJewelsInStones(string J, string S)
        {
            int count = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (J.Contains(S[i]))
                {
                    count++;
                }
            }
            return count;
        }
        /*Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
Each letter in the magazine string can only be used once in your ransom note.
Note:
You may assume that both strings contain only lowercase letters.

canConstruct("a", "b") -> false
canConstruct("aa", "ab") -> false
canConstruct("aa", "aab") -> true*/
        public bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> mylist = ransomNote.ToList();
            foreach(char c in magazine)
            {
                if (ransomNote.Contains(c))
                {
                    mylist.Remove(c);
                }
            }
            if (mylist.Count == 0)
                return true;
            return false;
        }
        /* Time effective solution*/
        public bool CanConstruct1(string ransomNote, string magazine)
        {
            int[] count = new int[26];
            foreach (char c in magazine)
            {
                count[c - 'a']++;
            }
            foreach (char c in ransomNote)
            {
                count[c - 'a']--;
                if (count[c - 'a'] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        /*Given a positive integer, output its complement number. 
         * The complement strategy is to flip the bits of its binary representation.
            Example 1:
            Input: 5
            Output: 2
            Explanation: The binary representation of 5 is 101 (no leading zero bits), and its complement is 010. So you need to output*/
        //Time effective One Line solution -  return num ^ ((int)Math.Pow(2, (int)Math.Log(num, 2) + 1) - 1);
        public int FindComplement(int num)
        {
            var res = 0;
            var result = "";
            while (num > 0)
            {
                res = num % 2;
                num = num / 2;
                result = (res == 0 ? 1 : 0).ToString() + res;
            }
            return Convert.ToInt32(result, 2);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.FirstBadVersion(5);

            string jewel = "aA";
            string stone = "aAAbbbb";
            p.NumJewelsInStones(jewel, stone);


        }
    }
}
