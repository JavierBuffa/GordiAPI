using API.Utils;
using API.Enums;
using System;

namespace API.Extencions
{
   public static class EnumToStringMethod
	{
		static public string GetDescription(this Roles This)
		{
			var type = typeof(Roles);
			var memInfo = type.GetMember(This.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
			return ((DescriptionAttribute)attributes[0]).Description;
		}

		public static Roles GetEnum(this string role)
		{
			Roles lane;
			if (role == "Top")
			{
				lane = Roles.Top;
			}	
			else if (role == "Jungle")
			{
				lane = Roles.Jungle;
			}
			else if (role == "Mid")
			{
				lane = Roles.Mid;
			}
			else if (role == "ADC")
			{
				lane = Roles.ADC;
			}
			else if (role == "Support")
			{
				lane = Roles.Support;
			}
			else
			{
				throw new Exception("Invalid Role");
			}
			return lane;
		
		}
	}
}