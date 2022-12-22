using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskTSUN
{
	public class Field
	{
		public string upperName { get; set; }

		public string type { get; set; }
		public bool isRequired { get; set; }
		public bool isReadOnly { get; set; }
		public bool isImmutable { get; set; }
		public bool isMultiple { get; set; }
		public bool isDynamic { get; set; }
		public string title { get; set; }
		public string listLabel { get; set; }
		public string formLabel { get; set; }
		public string filterLabel { get; set; }
		public object settings { get; set; }

	}
}
