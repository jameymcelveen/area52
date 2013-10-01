using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

namespace Area52.Models
{
	public class Property 
	{
		public string Name { get; set; }
		public Type Type { get; set; }

		public Property ()
		{
			
		}

		public Property (PropertyInfo propertyInfo)
		{
			LoadWithPropertyInfo(propertyInfo);	
		}

		void LoadWithPropertyInfo (PropertyInfo propertyInfo)
		{
			Name = propertyInfo.Name;
			Type = propertyInfo.PropertyType;
		}
	}

	public class Entity
	{
		public string Name { get; set; }
		public List<Property> Properties { get; set; }

		public Entity ()
		{
		}

		public Entity (Type type)
		{
			LoadWithType(type);
		}

		void LoadWithType (Type type)
		{
			Name = type.Name;

			Properties = new List<Property> ();
			foreach (var pi in type.GetProperties()) 
			{
				Properties.Add(new Property(pi));
			}
		}
	}

	public class DataContext
	{
		public string ModelAssembly = ConfigurationManager.AppSettings["ModelAssembly"];
		public string ModelNamespace = ConfigurationManager.AppSettings["ModelNamespace"];

		public List<Entity> Entities { get; set; }

		public DataContext ()
		{
			Entities = LoadEntities();
		}

		private List<Entity> LoadEntities ()
		{
			Assembly assembly = null;
			var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach(var a in loadedAssemblies) 
			{
				if (a.GetName().Name.Equals(ModelAssembly)) 
				{
					assembly = a;
					break;
				}
			}

			if (assembly == null) 
			{
				throw new Exception(string.Format("I could not find the assembly '{0}' in in my current app domain.", ModelAssembly));
			}

			var nameSpace = string.Format("{0}.Entities", ModelNamespace);
			var types = assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();


			var resultList = new List<Entity> ();
			if (types != null) 
			{
				foreach(var type in types)
				{
					resultList.Add(new Entity(type));
				}
			}

			return resultList;
		}
	}
}

