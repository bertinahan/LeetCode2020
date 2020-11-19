import java.util.*;
/**
Given a string s and a non-empty string p, find all the start indices of p's anagrams in s.

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
**/
public class Anagrams438
{
  public static void main(String[] args)
  {
    String s = "cbaebabacd";
    String p = "abc";
  }

  public static boolean isAnagram(int[] s, int[] p)
  {
    for(int i = 0; i < s.length; i++)
    {
      if (s[i] != p[i]) return false;
    }
    return true;
  }
  public static List<Integer> findAnagrams(String s, String p) {
    List<Integer> result = new ArrayList<Integer>();
    if (s.length() < p.length() || s == null || p == null) return result;
    int[] smap = new int[26];
    int[] pmap = new int[26];
    for(char x : p.toCharArray()) pmap[x-'a']++;
    for(char x : s.substring(0, p.length()).toCharArray()) smap[x-'a']++;
    int pointer = p.length();
    for (int i = pointer; i < s.length(); i++)
    {
      if(isAnagram(smap, pmap))
      {
        result.add(i-p.length());
      }
      smap[s.charAt(i)-'a']++;
      smap[s.charAt(i-p.length())]--;
    }
    if(isAnagram(smap, pmap)) result.add(s.length()-p.length());
    return result;
  }
}