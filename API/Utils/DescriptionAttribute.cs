using System;

namespace API.Utils

{
	public class DescriptionAttribute : Attribute
	{
		private readonly string _description;
		
		public DescriptionAttribute(string description)
		{
			_description = description;
		}
		
		public string Description
		{
			get
			{
				return _description;
			}
		}
	}
}