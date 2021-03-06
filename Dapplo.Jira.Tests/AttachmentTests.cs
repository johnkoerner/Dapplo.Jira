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

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Dapplo.Log;
using Xunit;
using Xunit.Abstractions;

#endregion

namespace Dapplo.Jira.Tests
{
	public class AttachmentTests : TestBase
	{
		public AttachmentTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async Task TestAttachment()
		{
			const string filename = "test.txt";
			const string testContent = "Testing 1 2 3";
			var attachment = await Client.Attachment.AttachAsync(TestIssueKey, testContent, filename);
			Assert.NotNull(attachment);
			Assert.StartsWith("text/plain", attachment.MimeType);

			if (attachment.ThumbnailUri != null)
			{
				var attachmentThumbnail = await Client.Attachment.GetThumbnailAsAsync<Bitmap>(attachment);
				Assert.NotNull(attachmentThumbnail);
				Assert.True(attachmentThumbnail.Width > 0);
			}

			var returnedContent = await Client.Attachment.GetContentAsAsync<string>(attachment);
			Assert.Equal(testContent, returnedContent);

			var hasBeenRemoved = false;
			var issue = await Client.Issue.GetAsync(TestIssueKey);
			foreach (var attachment2Delete in issue.Fields.Attachments.Where(x => x.Filename == filename))
			{
				Log.Info().WriteLine("Deleting {0} from {1}", attachment2Delete.Filename, attachment2Delete.Created);
				await Client.Attachment.DeleteAsync(attachment2Delete);
				hasBeenRemoved = true;
			}

			Assert.True(hasBeenRemoved);
		}
	}
}