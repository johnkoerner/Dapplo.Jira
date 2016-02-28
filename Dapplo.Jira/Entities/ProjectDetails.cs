﻿/*
	Dapplo - building blocks for desktop applications
	Copyright (C) 2015-2016 Dapplo

	For more information see: http://dapplo.net/
	Dapplo repositories are hosted on GitHub: https://github.com/dapplo

	This file is part of Dapplo.Jira

	Dapplo.Jira is free software: you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	Dapplo.Jira is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with Dapplo.Jira. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dapplo.Jira.Entities
{
	/// <summary>
	/// Project information
	/// See: https://docs.atlassian.com/jira/REST/latest/#api/2/project
	/// </summary>
	[DataContract]
	public class ProjectDetails : ProjectDigest
	{
		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "lead")]
		public User Lead { get; set; }

		[DataMember(Name = "projectCategory")]
		public ProjectCategory Category { get; set; }

		[DataMember(Name = "url")]
		public Uri BrowseUrl { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "assigneeType")]
		public string AssigneeType { get; set; }

		[DataMember(Name = "components")]
		public IList<Component> Components { get; set; }

		[DataMember(Name = "issueTypes")]
		public IList<IssueType> IssueTypes { get; set; }
	}
}
