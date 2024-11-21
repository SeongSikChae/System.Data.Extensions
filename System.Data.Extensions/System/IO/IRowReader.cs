namespace System.IO
{
	using Data;

	/// <summary>
	/// Stream 으로 부터 IRow를 읽어오는 Reader 인터페이스
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRowReader<T> : IDisposable where T : IRow
	{
		/// <summary>
		/// 기본 스트림을 가져옵니다.
		/// </summary>
		Stream BaseStream { get; }

		/// <summary>
		/// 현재 스트림 내의 위치를 설정합니다.
		/// </summary>
		long Seek(long offset, SeekOrigin origin);

		/// <summary>
		/// 현재 위치의 스트림에서 IRow를 읽습니다.
		/// </summary>
		T? Read();

		/// <summary>
		/// 현재 위치의 스트림에서 skip 개수 만큼 이후의 IRow를 읽습니다.
		/// </summary>
		T? Read(int skip);

		/// <summary>
		/// 현재 위치의 스트림에서 skip 개수 만큼 이후의 IRow를 count 만큼 읽습니다.
		/// </summary>
		IEnumerable<T?> Read(int skip, int count);

		/// <summary>
		/// IRowWriter 및 기본 스트림을 닫습니다.
		/// </summary>
		void Close();
	}
}
