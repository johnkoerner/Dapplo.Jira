﻿#region Dapplo 2017 - GNU Lesser General Public License

// Dapplo - building blocks for .NET applications
// Copyright (C) 2017 Dapplo
// 
// For more information see: http://dapplo.net/
// Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
// This file is part of Dapplo.Jira
// 
// Dapplo.Jira is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Dapplo.Jira is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have a copy of the GNU Lesser General Public License
// along with Dapplo.Jira. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

#endregion

#region Usings

using System.Collections.Generic;
using System.Runtime.Serialization;

#endregion

namespace Dapplo.Jira.Entities
{
	/// <summary>
	///     Container for the Error
	/// </summary>
	[DataContract]
	public class Error
	{
		/// <summary>
		///     The HTTP status code of the error
		/// </summary>
		[DataMember(Name = "status-code", EmitDefaultValue = false)]
		public int StatusCode { get; set; }

		/// <summary>
		///     The list of error messages
		/// </summary>
		[DataMember(Name = "errorMessages", EmitDefaultValue = false)]
		public IList<string> ErrorMessages { get; set; }

		/// <summary>
		///     The message
		/// </summary>
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public string Message { get; set; }

		/// <summary>
		/// A list of errors
		/// </summary>
		[DataMember(Name = "errors", EmitDefaultValue = false)]
		public IDictionary<string, string> Errors { get; set; }
	}
}