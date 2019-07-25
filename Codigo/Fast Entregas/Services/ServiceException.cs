using System;

namespace Services
{
	public class ServiceException : SystemException
	{

		public ServiceException(String mensagem, Exception inner)
			: base(mensagem, inner)
		{

		}

		public ServiceException(String mensagem)
			: base(mensagem)
		{

		}
	}
}
