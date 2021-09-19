using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Utilities
{
    public static class JsonUility
    {
		public static string ToJson(this object _data)
		{
			if (null == _data)
				return string.Empty;
			else
				return JsonConvert.SerializeObject(_data);
		}
	}
}