namespace System.IO
{
	using Data;
	using Text;

	/// <summary>
	/// Stream 에 DefaultRow를 기록하는 Writer
	/// </summary>
	public sealed class DefaultRowWriter : IRowWriter<DefaultRow>
	{
		/// <summary>
		/// 백업 저장소가 없는 DefaultRowWriter를 지정합니다.
		/// </summary>
		public static readonly DefaultRowWriter Null = new DefaultRowWriter();

		/// <summary>
		/// 지정된 스트림 및 문자 인코딩, ByteOrder 기반으로 DefaultRowWriter 를 초기화 하고 필요에 따라 스트림을 열어 둡니다.
		/// </summary>
		public DefaultRowWriter(Stream output, Encoding encoding, bool leaveOpen, ByteOrder byteOrder)
		{
			writer = new BinaryWriterV2(output, encoding, leaveOpen, byteOrder);
			inmemoryWriter = new BinaryWriterV2(memory, encoding, true, byteOrder);
		}

		private readonly BinaryWriter writer;
		private readonly MemoryStream memory = new MemoryStream();
		private readonly BinaryWriter inmemoryWriter;

		/// <summary>
		/// 지정된 스트림 및 문자 인코딩, ByteOrder 기반으로 DefaultRowWriter 를 초기화합니다.
		/// </summary>
		public DefaultRowWriter(Stream output, Encoding encoding, ByteOrder byteOrder) : this(output, encoding, false, byteOrder) { }

		/// <summary>
		/// 지정된 스트림 및 UTF-8 인코딩, ByteOrder 기반으로 DefaultRowWriter 를 초기화합니다.
		/// </summary>
		/// <param name="output"></param>
		/// <param name="byteOrder"></param>
		public DefaultRowWriter(Stream output, ByteOrder byteOrder) : this(output, Encoding.UTF8, false, byteOrder) { }

		private DefaultRowWriter() : this(Stream.Null, ByteOrder.LittleEndian) { }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public Stream BaseStream => writer.BaseStream;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public long Seek(long offset, SeekOrigin origin)
		{
			return writer.BaseStream.Seek(offset, origin);
		}

		/// <summary>
		/// DefaultRow를 기본 스트림에 씁니다.
		/// </summary>
		public void Write(DefaultRow row)
		{
			inmemoryWriter.Write(row.ColumnCount);
			foreach (string columnName in row.ColumnNames)
			{
				IColumn column = row.GetColumn(columnName);
				inmemoryWriter.WriteUTF8(columnName);
				inmemoryWriter.Write(column);
			}
			byte[] buffer = memory.ToArray();
			writer.Write(buffer.Length);
			writer.Write(buffer);
			memory.SetLength(0);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void Flush()
		{
			writer.Flush();
		}

		/// <summary>
		/// DefaultRowWriter 및 기본 스트림을 닫습니다.
		/// </summary>
		public void Close()
		{
			Dispose();
		}

		private bool disposed;

		/// <summary>
		/// DefaultRowWriter 인스턴스에서 사용하는 모든 리소스를 해제합니다.
		/// </summary>
		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				writer.Dispose();
				inmemoryWriter.Dispose();
				memory.Dispose();
				GC.SuppressFinalize(this);
			}
		}		
	}
}
