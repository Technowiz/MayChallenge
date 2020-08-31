using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Leet_MayChallenge
{
    class Program
    {
        /*Day -1-You are a product manager and currently leading a team to develop a new product. Unfortunately, the latest version of your product fails the quality check. Since each version is developed based on the previous version, all the versions after a bad version are also bad.
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
        /*Day 2 - You're given strings J representing the types of stones that are jewels, and S representing the stones you have.  Each character in S is a type of stone you have.  You want to know how many of the stones you have are also jewels.
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
        /*Day 3-Given an arbitrary ransom note string and another string containing letters from all the magazines, write a function that will return true if the ransom note can be constructed from the magazines ; otherwise, it will return false.
Each letter in the magazine string can only be used once in your ransom note.
Note:
You may assume that both strings contain only lowercase letters.

canConstruct("a", "b") -> false
canConstruct("aa", "ab") -> false
canConstruct("aa", "aab") -> true*/
        public bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> mylist = ransomNote.ToList();
            foreach (char c in magazine)
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
        /*Day 4 - Given a positive integer, output its complement number. 
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
        /*Day-5-Given a string, find the first non-repeating character in it and return it's index. If it doesn't exist, return -1.

Examples:

s = "leetcode"
return 0.

s = "loveleetcode",
return 2.*/
        public int FirstUniqChar(string s)
        {
            /*var ch = s.GroupBy(r => r).Where(r => r.Count() == 1).Select(r=>r.Key).FirstOrDefault();
            if (ch == '\0')
                return -1;
            return s.IndexOf(ch.ToString());*/
            for (int i = 0; i < s.Length; i++)
            {
                int index = s.IndexOf(s[i]);
                if (index != -1 && index == s.LastIndexOf(s[i]))
                {
                    return index;
                }
                else
                {
                    index = -1;
                }
            }
            return -1;

        }
        // Time effective solution
        public int FirstUniqChar1(string s)
        {
            var charAndCount = new int[256];

            foreach (var c in s)
            {
                charAndCount[c]++;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (charAndCount[s[i]] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        /*Day - 6-Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.

You may assume that the array is non-empty and the majority element always exist in the array.

Example 1:

Input: [3,2,3]
Output: 3
Example 2:

Input: [2,2,1,1,1,2,2]
Output: 2*/
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] = dict[nums[i]] + 1;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }

            }

            int max = dict.Values.Max();
            return dict.FirstOrDefault(x => x.Value == max).Key;
        }
        //Time Effective solution 
        public int MajorityElement1(int[] nums)
        {
            // Boyer-Moore Voting Algorithm
            var candidate = 0;
            var count = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                // eg. {5,7,7,5,7}
                if (count == 0)
                {
                    //cand=5//7
                    candidate = nums[i];
                    //count=1//1
                    count++;
                }
                else
                {
                    //count=0
                    if (nums[i] == candidate) count++;
                    else count--;
                }
            }

            return candidate;
        }


        /*Day -8-You are given an array coordinates, coordinates[i] = [x, y], where [x, y] represents the coordinate of a point. 
         * Check if these points make a straight line in the XY plane.*/

        public bool CheckStraightLine(int[][] coordinates)
        {
            if (coordinates.Length == 1 || coordinates.Length == 0)
                return true;
            int x0 = coordinates[0][0];
            int y0 = coordinates[0][1];
            int x1 = coordinates[1][0];
            int y1 = coordinates[1][1];
            //[[-4,-3],[1,0],[3,-1],[0,-1],[-5,2]]
            int dx = x1 - x0, dy = y1 - y0;
            //dx=5 , dy=3, slope is dy/dx
            foreach (var coord in coordinates)
            {
                int x = coord[0], y = coord[1];
                //Instead of checking dy/dx =(y1-y)/(x1-x), cross multiply
                //dx*(y1-y)=dy*(x1-x)
                if (dx * (y1 - y) != dy * (x1 - x))
                    return false;
            }
            return true;
        }


        /*Day -9-To find if a number is perfect square root or not eg 16 is perfect square*/
        public bool IsPerfectSquare(int num)
        {
            //My solution was return int.TryParse(Math.sqrt(num),out int val)
            long begin = 0;
            long end = num;
            while (begin <= end)
            {
                long mid = (end - begin) / 2 + begin;
                long mid2 = mid * mid;

                if (mid2 == num)
                {
                    return true;
                }
                if (mid2 < num)
                {
                    begin = mid + 1;
                }
                if (mid2 > num)
                {
                    end = mid - 1;
                }
            }
            return false;
        }
        /*Day-10-In a town, there are N people labelled from 1 to N.  There is a rumor that one of these people is secretly the town judge.

        If the town judge exists, then:
        The town judge trusts nobody.
        Everybody (except for the town judge) trusts the town judge.
        There is exactly one person that satisfies properties 1 and 2.
        You are given trust, an array of pairs trust[i] = [a, b] representing that the person labelled a trusts the person labelled b.

        If the town judge exists and can be identified, return the label of the town judge.  Otherwise, return -1.

        Example 1:
        Input: N = 2, trust = [[1,2]]
        Output: 2
        Example 2:
        Input: N = 3, trust = [[1,3],[2,3]]
        Output: 3
        Example 3:
        Input: N = 3, trust = [[1,3],[2,3],[3,1]]
        Output: -1
        Example 4:
        Input: N = 3, trust = [[1,2],[2,3]]
        Output: -1
        Example 5:
        Input: N = 4, trust = [[1,3],[1,4],[2,3],[2,4],[4,3]]
        Output: 3*/
        public int FindJudge(int N, int[][] trust)
        {
            if (trust.Length == 0)
                return N;
            if (trust.Length == 1)
                return trust[0][1];
            int[] num = new int[N + 1];
            HashSet<int> a = new HashSet<int>(trust.Length);
            for (int i = 0; i < trust.Length; i++)
            {
                a.Add(trust[i][0]);
                num[trust[i][1]] = num[trust[i][1]] + 1;

            }
            int max = Array.IndexOf(num, num.Max());
            if (!a.Contains(max) && (num.Max() == N - 1))
                return max;
            return -1;
        }
        /*An image is represented by a 2-D array of integers, each integer representing the pixel value of the image (from 0 to 65535).
        Given a coordinate (sr, sc) representing the starting pixel (row and column) of the flood fill, and a pixel value newColor, "flood fill" the image.
        To perform a "flood fill", consider the starting pixel, plus any pixels connected 4-directionally to the starting pixel of the same color as the starting pixel, plus any pixels connected 4-directionally to those pixels (also with the same color as the starting pixel), and so on. Replace the color of all of the aforementioned pixels with the newColor.
        At the end, return the modified image.

        Example 1:
        Input: 
        image = [[1,1,1],[1,1,0],[1,0,1]]
        sr = 1, sc = 1, newColor = 2
        Output: [[2,2,2],[2,2,0],[2,0,1]]
        Explanation: 
        From the center of the image (with position (sr, sc) = (1, 1)), all pixels connected 
        by a path of the same color as the starting pixel are colored with the new color.
        Note the bottom corner is not colored 2, because it is not 4-directionally connected
        to the starting pixel.*/
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor)
                return image;

            Fill(image, sr, sc, image[sr][sc], newColor);
            return image;
        }

        public void Fill(int[][] image, int i, int j, int color, int newColor)
        {
            if (i < 0 || i >= image.Length || j < 0 || j >= image[i].Length || image[i][j] != color)
                return;

            image[i][j] = newColor;
            Fill(image, i - 1, j, color, newColor);
            Fill(image, i + 1, j, color, newColor);
            Fill(image, i, j - 1, color, newColor);
            Fill(image, i, j + 1, color, newColor);
        }
        /*You are given a sorted array consisting of only integers where every element appears exactly twice, except for one element which appears exactly once. Find this single element that appears only once.
            Example 1:
            Input: [1,1,2,3,3,4,4,8,8]
            Output: 2
            Example 2:
            Input: [3,3,7,7,10,11,11]
            Output: 10*/
        public int SingleNonDuplicate(int[] nums)
        {
            var res = 0;
            foreach (var n in nums)
            {
                res ^= n;
            }
            return res;
        }
        /*Given a non-negative integer num represented as a string, remove k digits from the number so that the new number is the smallest possible.
        Note:
        The length of num is less than 10002 and will be ≥ k.
        The given num does not contain any leading zero.
        Example 1:

        Input: num = "1432219", k = 3
        Output: "1219"
        Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 which is the smallest.
        Example 2:

        Input: num = "10200", k = 1
        Output: "200"
        Explanation: Remove the leading 1 and the number is 200. Note that the output must not contain leading zeroes.
        Example 3:

        Input: num = "10", k = 2
        Output: "0"
        Explanation: Remove all the digits from the number and it is left with nothing which is 0.*/

        static string res = "";
        public string RemoveKdigits(string num, int k)
        {
            if (num.Length <= k)
                return "0";
            res = "0";
            buildLowestNumberRec(num, k);
            if (res != "0")
                res = res.TrimStart(new char[] { '0' });
            return res;
        }
        static void buildLowestNumberRec(string str,
                                          int n)
        {

            // If there are 0 characters to remove from str,  
            // append everything to result  
            if ((n == 0))
            {
                res += str;
                return;
            }

            int len = str.Length;

            // If there are more characters to  
            // remove than string length,  
            // then append nothing to result  
            if (len <= n)
                return;

            // Find the smallest character among  
            // first (n+1) characters of str.  
            int minIndex = 0;
            for (int i = 1; i <= n; i++)
                if (str[i] < str[minIndex])
                    minIndex = i;

            // Append the smallest character to result  
            res += str[minIndex];

            // substring starting from  
            // minIndex+1 to str.length() - 1.  
            string new_str = str.Substring(minIndex + 1);

            // Recur for the above substring  
            // and n equals to n-minIndex  
            buildLowestNumberRec(new_str, n - minIndex);
        }
        /*Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.
        Strings consists of lowercase English letters only and the length of both strings s and p will not be larger than 20,100.
        The order of output does not matter.

        Example 1:
        Input:
        s: "cbaebabacd" p: "abc"
        Output:
        [0, 6]

        Explanation:
        The substring with start index = 0 is "cba", which is an anagram of "abc".
        The substring with start index = 6 is "bac", which is an anagram of "abc".
        Example 2:

        Input:
        s: "abab" p: "ab"

        Output:
        [0, 1, 2]

        Explanation:
        The substring with start index = 0 is "ab", which is an anagram of "ab".
        The substring with start index = 1 is "ba", which is an anagram of "ab".
        The substring with start index = 2 is "ab", which is an anagram of "ab".*/
        public IList<int> FindAnagrams(string s, string p)
        {
            char[] ana = p.ToCharArray();
            Array.Sort(ana);
            string anag = new string(ana);
            List<int> index = new List<int>();
            //char[] subs;
            //s: "cbaebabacd" p: "abc"
            for (int i = 0; i < (s.Length - p.Length + 1); i++)//11-3//8
            {

                char[] subs = s.Substring(i, ana.Length).ToArray();
                Array.Sort(subs);
                if (anag == new string(subs))
                    index.Add(i);
            }
            return index;
        }
        public bool CheckInclusion(string s1, string s2)
        {
            int[] chars = new int[256];
            int count = 0;//"adc"
            //"dcda"
            foreach (char c in s1)
            {
                chars[c]++;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                if (i < s2.Length - s1.Length + 1)
                {
                    count++;
                    chars[s2[i]]--;
                }
                else
                    count = 0;
                if (count == s1.Length)
                    return true;
            }

            return false;
        }
        public string FrequencySort(string s)
        {
            int[] count = new int[256];
            foreach (char c in s)
                count[c]++;
            char[] ans = new char[s.Length];
            for (int i = 0; i < count.Length; i++)
            {
                ans[i] = Convert.ToChar(count[i]);
            }
            return new string(ans);
        }
        /*Given two lists of closed intervals, each list of intervals is pairwise disjoint and in sorted order.
         Return the intersection of these two interval lists.
        (Formally, a closed interval [a, b] (with a <= b) denotes the set of real numbers x with a <= x <= b.  The intersection of two closed intervals is a set of real numbers that is either empty, or can be represented as a closed interval.  For example, the intersection of [1, 3] and [2, 4] is [2, 3].)

        Example 1:

        Input: A = [[0,2],[5,10],[13,23],[24,25]], B = [[1,5],[8,12],[15,24],[25,26]]
        Output: [[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]
        Reminder: The inputs and the desired output are lists of Interval objects, and not arrays or lists.*/
        public int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            //Merge

            int i = 0; int j = 0;
            List<int[]> result = new List<int[]>();
            while (i < A.Length && j < B.Length)
            {
                int low = Math.Max(A[i][0], B[j][0]);
                int hi = Math.Min(A[i][1], B[j][1]);

                if (low <= hi)
                    result.Add(new int[2] { low, hi });

                if (A[i][1] > B[j][1])
                    j++;
                else
                    i++;
            }
            return result.ToArray();
        }
        /*We have a list of points on the plane.  Find the K closest points to the origin (0, 0).
            (Here, the distance between two points on a plane is the Euclidean distance.)
            You may return the answer in any order.  The answer is guaranteed to be unique (except for the order that it is in.)

            Example 1:

            Input: points = [[1,3],[-2,2]], K = 1
            Output: [[-2,2]]
            Explanation: 
            The distance between (1, 3) and the origin is sqrt(10).
            The distance between (-2, 2) and the origin is sqrt(8).
            Since sqrt(8) < sqrt(10), (-2, 2) is closer to the origin.
            We only want the closest K = 1 points from the origin, so the answer is just [[-2,2]].
            Example 2:

            Input: points = [[3,3],[5,-1],[-2,4]], K = 2
            Output: [[3,3],[-2,4]]
            (The answer [[-2,4],[3,3]] would also be accepted.) */
        public int[][] KClosest(int[][] points, int K)
        {

            Dictionary<Double, int[]> sumDict = new Dictionary<double, int[]>();
            
            for(int i=0;i<points.Length;i++)
            {
                sumDict.Add(Math.Sqrt((double)points[i][0]*points[i][0]+points[i][1]*points[i][1]),points[i]);
            }
            var result = sumDict.OrderByDescending(x => x.Key).Take(K);
            int[][] resultArr = new int[result.Count()][];
            int count = 0;
            foreach (var item in result)
            {
                resultArr[count++]=item.Value;
            }
            return resultArr;
            
        }
        /*There are a total of numCourses courses you have to take, labeled from 0 to numCourses-1.
        Some courses may have prerequisites, for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]
        Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

        Example 1:
        Input: numCourses = 2, prerequisites = [[1,0]]
        Output: true
        Explanation: There are a total of 2 courses to take. 
                     To take course 1 you should have finished course 0. So it is possible.
        Example 2:
        Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
        Output: false
        Explanation: There are a total of 2 courses to take. 
                     To take course 1 you should have finished course 0, and to take course 0 you should
                     also have finished course 1. So it is impossible.*/
        List<int>[] graph;
        int[] visited;

        const int NotVisited = 0;
        const int Visiting = 1;
        const int Visited = 2;

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            graph = new List<int>[numCourses];
            visited = new int[numCourses];

            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
                visited[i] = NotVisited;
            }

            foreach (int[] pair in prerequisites)
            {
                graph[pair[0]].Add(pair[1]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == Visited) continue;
                if (!Dfs(i)) return false;
            }

            return true;
        }

        public bool Dfs(int node)
        {
            visited[node] = Visiting;

            foreach (int prereq in graph[node])
            {
                if (visited[prereq] == Visited)
                    continue;

                if (visited[prereq] == Visiting)
                    return false;

                bool canFinish = Dfs(prereq);
                if (!canFinish) return false;
            }

            visited[node] = Visited;
            return true;
        }
        /*Given two words word1 and word2, find the minimum number of operations required to convert word1 to word2.
        You have the following 3 operations permitted on a word:
        Insert a character
        Delete a character
        Replace a character
        Example 1:

        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        Example 2:

        Input: word1 = "intention", word2 = "execution"
        Output: 5
        Explanation: 
        intention -> inention (remove 't')
        inention -> enention (replace 'i' with 'e')
        enention -> exention (replace 'n' with 'x')
        exention -> exection (replace 'n' with 'c')
        exection -> execution (insert 'u')*/
        public int MinDistance(string word1, string word2)
        {
            // Create a table to store 
            // results of subproblems 
            int m = word1.Length;
            int n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];

            // Fill d[][] in bottom up manner 
            for (int i = 0; i <= m; i++)
            {//Loop through first word 
                for (int j = 0; j <= n; j++)
                { //for every letter in first word , loop through secon word
                  // If first string is empty, only option is to 
                  // insert all characters of second string 
                    if (i == 0)

                        // Min. operations = j 
                        dp[i, j] = j;//first for whole of j values are inserted

                    // If second string is empty, only option is to 
                    // remove all characters of second string 
                    else if (j == 0)

                        // Min. operations = i 
                        dp[i, j] = i;

                    // If last characters are same, ignore last char 
                    // and recur for remaining string 
                    else if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    // If the last character is different, consider all 
                    // possibilities and find the minimum 
                    else
                        dp[i, j] = 1 + min(dp[i, j - 1], // Insert 
                                           dp[i - 1, j], // Remove 
                                           dp[i - 1, j - 1]); // Replace 
                }
            }

            return dp[m, n];
        }
        static int min(int x, int y, int z)
        {
            if (x <= y && x <= z)
                return x;
            if (y <= x && y <= z)
                return y;
            else
                return z;
        }

        static void Main(string[] args)
        {
            
            Program p = new Program();
            p.MinDistance("intention", "execution");
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            a.AddRange(b);
            int[][] a = new int[2][];
            //[[1,3],[-2,2]], K = 1
            a[0] = new int[] { 1,3 };
            a[1] = new int[] { -2,2 };

            p.KClosest(a, 1);
            //[[1,1],[1,1],[0,2],[1,3]]
            //a[2] = new int[] { 13,23 };
            //a[3] = new int[] { 24,25 };


        int[][] b = new int[4][];

            b[0] = new int[] { 1,5 };
            b[1] = new int[] { 8,12 };//[[1,1],[1,1],[0,2],[1,3]]
            b[2] = new int[] { 15,24 };
            b[3] = new int[] {25,26 };
            p.IntervalIntersection(a, b);
            p.FrequencySort("cccaaa");
            p.CheckInclusion("adc", "dcda");
            p.FirstBadVersion(5);
            p.FindAnagrams( "cbaebabacd" ,"abc");

            p.RemoveKdigits("1432219", 3);

            string jewel = "aA";
            string stone = "aAAbbbb";
            p.NumJewelsInStones(jewel, stone);

            p.FirstUniqChar("LL");

            int[] nums = {6,5,5 };
            p.MajorityElement(nums);

            int[][] coord = new int[5][];

            coord[0] = new int[] { -4, -3 };
            coord[1] = new int[] { 1, 0 };//[[1,1],[1,1],[0,2],[1,3]]
            coord[2] = new int[] { 3, -1 };
            coord[3] = new int[] { 0, -1 };
            coord[4] = new int[] { -5, 2 };
            p.CheckStraightLine(coord);

            // [[1,3],[1,4],[2,3],[2,4],[4,3]]
            int[][] townjudge = new int[5][];

            townjudge[0] = new int[] { 1, 3 };
            townjudge[1] = new int[] { 1, 4 };//[[1,1],[1,1],[0,2],[1,3]]
            townjudge[2] = new int[] { 2, 3 };
            townjudge[3] = new int[] { 2, 4 };
            townjudge[4] = new int[] { 4, 3 };
            p.FindJudge(4,townjudge);
            //coordiChenates[0] = { -4,-3};//[[-4,-3],[1,0],[3,-1],[0,-1],[-5,2]]
            //,[1,0],[3,-1],[0,-1],[-5,2]]

            /*Binary Tree Driver Code*/
            TreeNode tree = new TreeNode();
            tree.val = 1;
            tree.left = new TreeNode(0);
            tree.right = new TreeNode(2);
            //tree.left.left = new TreeNode(4);
            tree.left.right = new TreeNode(3);
            BinaryTree bt = new BinaryTree();
            bt.PreorderTraversal(tree);


        }
    }
}
