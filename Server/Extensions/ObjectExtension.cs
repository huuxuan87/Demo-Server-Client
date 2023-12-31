﻿using System.Reflection;

namespace Server.Extensions
{
    public static class ObjectExtension
    {
        public static void SetPropertyByName(this object obj, string propertyName, object newValue)
        {
            if (obj != null)
            {
                var property = obj.GetType().GetProperty(propertyName);

                if (property != null)
                {
                    property.SetValue(obj, newValue);
                }
            }
        }

        public static void DbCommonUpdate(this object obj, int id)
        {
            if (id > 0)
            {
                obj.SetPropertyByName("NgaySua", DateTime.Now);
            }
            else
            {
                obj.SetPropertyByName("NgayTao", DateTime.Now);
            }
        }
    }
}
