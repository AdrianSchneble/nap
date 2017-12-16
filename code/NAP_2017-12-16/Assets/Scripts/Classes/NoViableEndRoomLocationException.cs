using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoViableEndRoomLocationException : Exception
{
	public NoViableEndRoomLocationException()
	{
	}
}