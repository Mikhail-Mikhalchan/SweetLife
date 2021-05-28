using System;
using System.IO;

namespace SweetLife.Logic.Repositories.Mssql.File.GetById
{
    public class Result : IDisposable
    {
		public string ContentType { get; set; }
		public Stream Content { get; set; }
		public IDisposable Reader { get; set; }

		public void Dispose()
		{
			Reader?.Dispose();
			Content?.Dispose();
		}
	}
}
