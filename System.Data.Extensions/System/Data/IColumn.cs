namespace System.Data
{
	using Net;
	using Numerics;

	/// <summary>
	/// Column 유형 열거형
	/// </summary>
	public enum ColumnType
	{
		/// <summary>
		/// <see cref="System.SByte"/> 형식 Column 유형
		/// </summary>
		SByte,
		/// <summary>
		/// <see cref="System.Byte"/> 형식 Column 유형
		/// </summary>
		Byte,
		/// <summary>
		/// <see cref="System.Int16"/> 형식 Column 유형
		/// </summary>
		Int16,
		/// <summary>
		/// <see cref="System.UInt16"/> 형식 Column 유형
		/// </summary>
		UInt16,
		/// <summary>
		/// <see cref="System.Int32"/> 형식 Column 유형
		/// </summary>
		Int32,
		/// <summary>
		/// <see cref="System.UInt32"/> 형식 Column 유형
		/// </summary>
		UInt32,
		/// <summary>
		/// <see cref="System.Int64"/> 형식 Column 유형
		/// </summary>
		Int64,
		/// <summary>
		/// <see cref="System.UInt64"/> 형식 Column 유형
		/// </summary>
		UInt64,
		/// <summary>
		/// <see cref="System.Half"/> 형식 Column 유형
		/// </summary>
		Half,
		/// <summary>
		/// <see cref="System.Single"/> 형식 Column 유형
		/// </summary>
		Single,
		/// <summary>
		/// <see cref="System.Double"/> 형식 Column 유형
		/// </summary>
		Double,
		/// <summary>
		/// <see cref="System.Decimal"/> 형식 Column 유형
		/// </summary>
		Decimal,
		/// <summary>
		/// <see cref="System.String"/> 형식 Column 유형
		/// </summary>
		String,
		/// <summary>
		/// <see cref="System.Net.IPAddress"/> 형식 Column 유형
		/// </summary>
		IPAddress,
		/// <summary>
		/// byte[] 형식의 Column 유형
		/// </summary>
		Bytes,
		/// <summary>
		/// NULL 형식 Column 유형
		/// </summary>
		NULL = int.MaxValue
	}

	/// <summary>
	/// Column 구현을 위한 인터페이스
	/// </summary>
	public interface IColumn : IComparable<IColumn>
	{
		/// <summary>
		/// Column 구현체의 유형이 무엇인지 가져오는 속성
		/// </summary>
		ColumnType Type { get; }
	}

	/// <summary>
	/// <inheritdoc/>
	/// </summary>
	public interface IColumn<T> : IColumn
	{
		/// <summary>
		/// Column 값을 가져옵니다.
		/// </summary>
		T Value { get; }
	}

	/// <summary>
	/// <see cref="System.SByte"/> 형식의 Column 구현체
	/// </summary>
	public sealed class SByteColumn(sbyte value) : IColumn<sbyte>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.SByte;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public sbyte Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other is null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			SByteColumn f = (SByteColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not SByteColumn)
				return false;
			SByteColumn other = (SByteColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Byte"/> 형식의 Column 구현체
	/// </summary>
	public sealed class ByteColumn(byte value) : IColumn<byte>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Byte;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public byte Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			ByteColumn f = (ByteColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not ByteColumn)
				return false;
			ByteColumn other = (ByteColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Int16"/> 형식의 Column 구현체
	/// </summary>
	public sealed class Int16Column(short value) : IColumn<short>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Int16;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public short Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			Int16Column f = (Int16Column)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not Int16Column)
				return false;
			Int16Column other = (Int16Column)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.UInt16"/> 형식의 Column 구현체
	/// </summary>
	public sealed class UInt16Column(ushort value) : IColumn<ushort>
	{
		/// <inheritdoc/>
		public ColumnType Type => ColumnType.UInt16;

		/// <inheritdoc/>
		public ushort Value => value;

		/// <inheritdoc/>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			UInt16Column f = (UInt16Column)other;
			return Value.CompareTo(f.Value);
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj)
		{
			if (obj is not UInt16Column)
				return false;
			UInt16Column other = (UInt16Column)obj;
			return Equals(value, other.Value);
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Int32"/> 형식의 Column 구현체
	/// </summary>
	public sealed class Int32Column(int value) : IColumn<int>
	{
		/// <inheritdoc/>
		public ColumnType Type => ColumnType.Int32;

		/// <inheritdoc/>
		public int Value => value;

		/// <inheritdoc/>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			Int32Column f = (Int32Column)other;
			return Value.CompareTo(f.Value);
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj)
		{
			if (obj is not Int32Column)
				return false;
			Int32Column other = (Int32Column)obj;
			return Equals(value, other.Value);
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.UInt32"/> 형식의 Column 구현체
	/// </summary>
	public sealed class UInt32Column(uint value) : IColumn<uint>
	{
		/// <inheritdoc/>
		public ColumnType Type => ColumnType.UInt32;

		/// <inheritdoc/>
		public uint Value => value;

		/// <inheritdoc/>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			UInt32Column f = (UInt32Column)other;
			return Value.CompareTo(f.Value);
		}

		/// <inheritdoc/>
		public override bool Equals(object? obj)
		{
			if (obj is not UInt32Column)
				return false;
			UInt32Column other = (UInt32Column)obj;
			return Equals(value, other.Value);
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <inheritdoc/>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Int64"/> 형식의 Column 구현체
	/// </summary>
	public sealed class Int64Column(long value) : IColumn<long>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Int64;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public long Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			Int64Column f = (Int64Column)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not Int64Column)
				return false;
			Int64Column other = (Int64Column)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.UInt64"/> 형식의 Column 구현체
	/// </summary>
	public sealed class UInt64Column(ulong value) : IColumn<ulong>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.UInt64;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ulong Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			UInt64Column f = (UInt64Column)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not UInt64Column)
				return false;
			UInt64Column other = (UInt64Column)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Half"/> 형식의 Column 구현체
	/// </summary>
	public sealed class HalfColumn(Half value) : IColumn<Half>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Half;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public Half Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			HalfColumn f = (HalfColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not HalfColumn)
				return false;
			HalfColumn other = (HalfColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Single"/> 형식의 Column 구현체
	/// </summary>
	public sealed class SingleColumn(float value) : IColumn<float>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Single;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public float Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			SingleColumn f = (SingleColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not SingleColumn)
				return false;
			SingleColumn other = (SingleColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Double"/> 형식의 Column 구현체
	/// </summary>
	public sealed class DoubleColumn(double value) : IColumn<double>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Double;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public double Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			DoubleColumn f = (DoubleColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not DoubleColumn)
				return false;
			DoubleColumn other = (DoubleColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.Decimal"/> 형식의 Column 구현체
	/// </summary>
	public sealed class DecimalColumn(decimal value) : IColumn<decimal>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Double;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public decimal Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			DecimalColumn f = (DecimalColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not DecimalColumn)
				return false;
			DecimalColumn other = (DecimalColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value.ToString();
		}
	}

	/// <summary>
	/// <see cref="System.String"/> 형식의 Column 구현체
	/// </summary>
	public sealed class StringColumn(string value) : IColumn<string>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.String;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public string Value => value;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			StringColumn f = (StringColumn)other;
			return Value.CompareTo(f.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not StringColumn)
				return false;
			StringColumn other = (StringColumn)obj;
			return Equals(value, other.Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return value;
		}
	}

	/// <summary>
	/// <see cref="System.Net.IPAddress"/> 형식의 Column 구현체
	/// </summary>
	public sealed class IPAddressColumn(IPAddress address) : IColumn<IPAddress>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public IPAddress Value => address;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.IPAddress;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other == null)
				return 1;
			int compare = Type.CompareTo(other.Type);
			if (compare != 0)
				return compare;
			IPAddressColumn f = (IPAddressColumn)other;
			return new BigInteger(Value.GetAddressBytes()).CompareTo(new BigInteger(f.Value.GetAddressBytes()));
		}
	}

	/// <summary>
	/// byte[] 형식의 Column Abstract
	/// </summary>
	public abstract class BytesColumn : IColumn<byte[]>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public abstract byte[] Value { get; }

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.Bytes;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public abstract int CompareTo(IColumn? other);
	}

	/// <summary>
	/// 존재하지 않는 Column에 대한 구현체
	/// </summary>
	public sealed class NullColumn : IColumn<object?>
	{
		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public object? Value => null;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public ColumnType Type => ColumnType.NULL;

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public int CompareTo(IColumn? other)
		{
			if (other is null)
				return 1;
			return Type.CompareTo(other.Type);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override bool Equals(object? obj)
		{
			if (obj is not NullColumn)
				return false;
			return true;
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override int GetHashCode()
		{
			return HashCode.Combine(Type, Value);
		}

		/// <summary>
		/// <inheritdoc/>
		/// </summary>
		public override string ToString()
		{
			return "null";
		}
	}
}
