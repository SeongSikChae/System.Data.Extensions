# System.Data namespace Extensions

* ColumnType enum (SByte, Byte, Int16, UInt16, Int64, UInt64, Half, Single, Double, Decimal, String, IPAddress, Bytes, NULL)

## IColumn interface

* SByteColumn
* ByteColumn
* Int16Column
* UInt16Column
* Int32Column
* UInt32Column
* Int64Column
* UInt64Column
* HalfColumn
* SingleColumn
* DoubleColumn
* DecimalColumn
* StringColumn
* IPAddressColumn
* BytesColumn
* NullColumn

## IRow interface

* DefaultRow

## System.IO namespace Extensions

### BinaryReader Extensions

* IColumn? ReadColumn()

### BinaryWriter Extensions

* void Wrtie(IColumn column)

## IRowReader interface

* DefaultRowReader

## IRowWriter

* DefaultRowWriter