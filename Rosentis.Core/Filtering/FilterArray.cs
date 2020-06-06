using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rosentis.Core.Filtering
{
	public static class FilterArray
	{
		public static List<int> getIntersect(List<int> arr1, List<int> arr2)
		{
			var intersect = new List<int>();

			for (var i = 0; i < arr2.Count; i++)
			{
				if (arr1.Contains(arr2[i]))
                intersect.Add(arr2[i]);
		}
		return intersect;
		}        
    }
}