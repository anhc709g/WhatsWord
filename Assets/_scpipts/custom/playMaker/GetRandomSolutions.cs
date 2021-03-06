// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameObject)]
	[Tooltip("Finds the Child of a GameObject by Name and/or Tag. Use this to find attach points etc. NOTE: This action will search recursively through all children and return the first match; To find a specific child use Find Child.")]
	public class GetRandomSolutions : FsmStateAction
	{
 
        [Tooltip("Get Puzzle from DB")]
		public string poolId;

        [RequiredField]
        public FsmString currentSolution; 

 
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the id of puzzle")]
        public FsmArray randomSolutionArray;

        public override void Reset()
		{
            poolId = null;
            randomSolutionArray = null;
		}

		public override void OnEnter()
		{
             DoGetpuzzle() ;

			Finish();
		}

		void DoGetpuzzle()
		{
           // Debug.Log("input=" + currentSolution.Value);
            string[] val = DbHelper.getInstance().getRandomPuzzle(currentSolution.Value);
           // Debug.Log("val="+ string.Join(",",val));
            randomSolutionArray.Values = val;
           // Debug.Log("randomSolutionArray.Values=" + string.Join(",", (string[])randomSolutionArray.Values));
          //  Debug.Log("RandomSolutionArray.Values="+ RandomSolutionArray.Values.Length);
        }
        void reshuffle(string[] texts)
        {
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (int t = 0; t < texts.Length; t++)
            {
                string tmp = texts[t];
                int r = Random.Range(t, texts.Length);
                texts[t] = texts[r];
                texts[r] = tmp;
            }
        }
        string[] StringToCharArray(string str)
        {
            string[] strarr = new string[str.Length];
            int i = 0;
            foreach (char c in str.ToCharArray())
            {
                strarr[i] = c.ToString();
                i++;
            }
            return strarr;
        }
        public static string GenerateRandomString(int length)
        {
            System.Random random=new System.Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            System.Text.StringBuilder result = new System.Text.StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
        public override string ErrorCheck()
		{
	
			return null;
		}

	}
}