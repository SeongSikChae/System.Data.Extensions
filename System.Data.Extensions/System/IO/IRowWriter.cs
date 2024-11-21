namespace System.IO
{
	using Data;

	/// <summary>
	/// Stream 에 IRow 를 기록하는 Writer 인터페이스
	/// </summary>
	public interface IRowWriter<T> : IDisposable where T : IRow
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
		/// IRow를 기본 스트림에 씁니다.
		/// </summary>
		void Write(T row);

		/// <summary>
		/// 현재 기록기에 대한 모든 버퍼를 지우고 버퍼링된 데이터가 기본 디바이스에 기록되도록 합니다.
		/// </summary>
		void Flush();

		/// <summary>
		/// IRowWriter 및 기본 스트림을 닫습니다.
		/// </summary>
		void Close();
	}
}
