using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.Misc
{
    class NumberFormatter
    {
		public enum suffixes
		{
			p, // p is a placeholder if the value is under 1 thousand
			K, // Thousand
			M, // Million
			B, // Billion
			T, // Trillion
			Q, //Quadrillion
		}

		//Formats numbers in Millions, Billions, etc.
		public static string numberFormat(double value)
		{
			int decimals = 2; //How many decimals to round to
			string r = value.ToString(); //Get a default return value

			foreach (suffixes suffix in Enum.GetValues(typeof(suffixes))) //For each value in the suffixes enum
			{
				var currentVal = 1 * Math.Pow(10, (int)suffix * 3); //Assign the amount of digits to the base 10
				var suff = Enum.GetName(typeof(suffixes), (int)suffix); //Get the suffix value
				if ((int)suffix == 0) //If the suffix is the p placeholder
					suff = String.Empty; //set it to an empty string

				if (value < 1000)
					return value.ToString("###");
				else if (value >= currentVal)
					r = Math.Round((value / currentVal), decimals, MidpointRounding.ToEven).ToString() + suff;
			}
			return r; 
		}
	}
}
