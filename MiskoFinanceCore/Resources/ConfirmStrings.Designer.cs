﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
namespace MiskoFinanceCore.Resources
{


	/// <summary>
	///   A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	// This class was auto-generated by the StronglyTypedResourceBuilder
	// class via a tool like ResGen or Visual Studio.
	// To add or remove a member, edit your .ResX file then rerun ResGen
	// with the /str option, or rebuild your VS project.
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	public class ConfirmStrings {
		
		private static global::System.Resources.ResourceManager resourceMan;
		
		private static global::System.Globalization.CultureInfo resourceCulture;
		
		[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
		internal ConfirmStrings() {
		}
		
		/// <summary>
		///   Returns the cached ResourceManager instance used by this class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Resources.ResourceManager ResourceManager {
			get {
				if (Object.ReferenceEquals(resourceMan, null)) {
					global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MiskoFinanceCore.Resources.ConfirmStrings", typeof(ConfirmStrings).Assembly);
					resourceMan = temp;
				}
				return resourceMan;
			}
		}
		
		/// <summary>
		///   Overrides the current thread's CurrentUICulture property for all
		///   resource lookups using this strongly typed resource class.
		/// </summary>
		[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
		public static global::System.Globalization.CultureInfo Culture {
			get {
				return resourceCulture;
			}
			set {
				resourceCulture = value;
			}
		}
		
		/// <summary>
		///   Looks up a localized String similar to Confirmation.
		/// </summary>
		public static String conConfirmation {
			get {
				return ResourceManager.GetString("conConfirmation", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized String similar to User {0} does not exist yet. Add new user?.
		/// </summary>
		public static String conConfirmNewUser {
			get {
				return ResourceManager.GetString("conConfirmNewUser", resourceCulture);
			}
		}
		
		/// <summary>
		///   Looks up a localized String similar to Create new account {0}?.
		/// </summary>
		public static String conCreateNewAccount {
			get {
				return ResourceManager.GetString("conCreateNewAccount", resourceCulture);
			}
		}
	}
}
