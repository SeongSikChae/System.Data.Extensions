namespace System.IO
{
	using Data;
	using Text;

	/// <summary>
	/// Stream 으로 부터 DefaultRow 를 읽어오는 Reader
	/// </summary>
	public sealed class DefaultRowReader(Stream input, Encoding encoding, bool leaveOpen, Endian endian) : IRowReader<DefaultRow>
	{
		/// <summary>
		/// 백업 저장소가 없는 DefaultRowReader를 지정합니다.
		/// </summary>
		public static readonly DefaultRowReader Null = new DefaultRowReader();

		private readonly BinaryReader reader = new EndianBinaryReader(input, encoding, leaveOpen, endian);

		/// <summary>
		/// 지정된 스트림 및 문자 인코딩, Endian 기반으로 DefaultRowReader 를 초기화 합니다.
		/// </summary>
		public DefaultRowReader(Stream input, Encoding encoding, Endian endian) : this(input, encoding, false, endian) { }

		/// <summary>
		/// 지정된 스트림 및 UTF-8 인코딩, Endian 기반으로 DefaultRowReader 를 초기화 합니다.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="endian"></param>
		public DefaultRowReader(Stream input, Endian endian) : this(input, Encoding.UTF8, false, endian) { }

		private DefaultRowReader() : this(Stream.Null, Endian.LittleEndian) { }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public Stream BaseStream => reader.BaseStream;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public long Seek(long offset, SeekOrigin origin)
		{
			return reader.BaseStream.Seek(offset, origin);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public DefaultRow? Read()
		{
			long position = reader.BaseStream.Position;
			try
			{
				reader.ReadInt32();
				DefaultRow row = new DefaultRow();
				int columnCount = reader.ReadInt32();
				for (int index = 0; index < columnCount; index++)
				{
					string columnName = reader.ReadUTF8();
					IColumn? column = reader.ReadColumn();
					if (column is not null)
						row.SetColumn(columnName, column);
					else
						row.SetColumn(columnName, new NullColumn());
				}
				return row;
			} 
			catch(Exception)
			{
				reader.BaseStream.Position = position;
				return null;
			}
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public DefaultRow? Read(int skip)
		{
			for (int index = 0; index < skip; index++)
			{
				int size = reader.ReadInt32();
				Seek(size, SeekOrigin.Current);
			}
			return Read();
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public IEnumerable<DefaultRow?> Read(int skip, int count)
		{
			for (int index = 0; index < skip; index++)
			{
				int size = reader.ReadInt32();
				Seek(size, SeekOrigin.Current);
			}
			for (int index = 0; index < count; index++)
				yield return Read();
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void Close()
		{
			Dispose();
		}

		private bool disposed;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				reader.Dispose();
				GC.SuppressFinalize(this);
			}
		}
	}
}
