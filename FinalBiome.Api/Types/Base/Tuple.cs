namespace FinalBiome.Api.Types
{
    public abstract class TupleBase : Codec
    {
#pragma warning disable CS8618
        public Codec[] Value { get; internal set; }
#pragma warning restore CS8618
        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }
            return result.ToArray();
        }
    }

    public class Tuple : TupleBase 
    {
        public override string TypeName() => $"()";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;
#pragma warning disable CA1825
            Value = new Codec[0];
#pragma warning restore CA1825

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init()
        {
            var bytes = new List<byte>();
            bytes.ToArray();
#pragma warning disable CA1825
            Value = new Codec[0];
#pragma warning restore CA1825

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0> : TupleBase  where T0 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[1];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.ToArray();

            Value = new Codec[1];
            Value[0] = t0;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1> : TupleBase  where T0 : Codec, new() where T1 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[2];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.ToArray();

            Value = new Codec[2];
            Value[0] = t0;
            Value[1] = t1;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1, T2> : TupleBase  where T0 : Codec, new() where T1 : Codec, new() where T2 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()}, {new T2().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[3];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            var t2 = new T2();
            t2.Decode(bytes, ref pos);
            Value[2] = t2;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1, T2 t2)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.AddRange(t2.Encode());
            bytes.ToArray();

            Value = new Codec[3];
            Value[0] = t0;
            Value[1] = t1;
            Value[2] = t2;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1, T2, T3> : TupleBase  where T0 : Codec, new() where T1 : Codec, new() where T2 : Codec, new() where T3 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()}, {new T2().TypeName()}, {new T3().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[4];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            var t2 = new T2();
            t2.Decode(bytes, ref pos);
            Value[2] = t2;

            var t3 = new T3();
            t3.Decode(bytes, ref pos);
            Value[3] = t3;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1, T2 t2, T3 t3)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.AddRange(t2.Encode());
            bytes.AddRange(t3.Encode());
            bytes.ToArray();

            Value = new Codec[4];
            Value[0] = t0;
            Value[1] = t1;
            Value[2] = t2;
            Value[3] = t3;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1, T2, T3, T4> : TupleBase  where T0 : Codec, new() where T1 : Codec, new() where T2 : Codec, new() where T3 : Codec, new() where T4 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()}, {new T2().TypeName()}, {new T3().TypeName()}, {new T4().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[5];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            var t2 = new T2();
            t2.Decode(bytes, ref pos);
            Value[2] = t2;

            var t3 = new T3();
            t3.Decode(bytes, ref pos);
            Value[3] = t3;

            var t4 = new T4();
            t4.Decode(bytes, ref pos);
            Value[4] = t4;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.AddRange(t2.Encode());
            bytes.AddRange(t3.Encode());
            bytes.AddRange(t4.Encode());
            bytes.ToArray();

            Value = new Codec[5];
            Value[0] = t0;
            Value[1] = t1;
            Value[2] = t2;
            Value[3] = t3;
            Value[4] = t4;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1, T2, T3, T4, T5> : TupleBase  where T0 : Codec, new() where T1 : Codec, new() where T2 : Codec, new() where T3 : Codec, new() where T4 : Codec, new() where T5 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()}, {new T2().TypeName()}, {new T3().TypeName()}, {new T4().TypeName()}, {new T5().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[6];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            var t2 = new T2();
            t2.Decode(bytes, ref pos);
            Value[2] = t2;

            var t3 = new T3();
            t3.Decode(bytes, ref pos);
            Value[3] = t3;

            var t4 = new T4();
            t4.Decode(bytes, ref pos);
            Value[4] = t4;

            var t5 = new T5();
            t5.Decode(bytes, ref pos);
            Value[5] = t5;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.AddRange(t2.Encode());
            bytes.AddRange(t3.Encode());
            bytes.AddRange(t4.Encode());
            bytes.AddRange(t5.Encode());
            bytes.ToArray();

            Value = new Codec[6];
            Value[0] = t0;
            Value[1] = t1;
            Value[2] = t2;
            Value[3] = t3;
            Value[4] = t4;
            Value[5] = t5;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1, T2, T3, T4, T5, T6> : TupleBase  where T0 : Codec, new() where T1 : Codec, new() where T2 : Codec, new() where T3 : Codec, new() where T4 : Codec, new() where T5 : Codec, new() where T6 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()}, {new T2().TypeName()}, {new T3().TypeName()}, {new T4().TypeName()}, {new T5().TypeName()}, {new T6().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[7];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            var t2 = new T2();
            t2.Decode(bytes, ref pos);
            Value[2] = t2;

            var t3 = new T3();
            t3.Decode(bytes, ref pos);
            Value[3] = t3;

            var t4 = new T4();
            t4.Decode(bytes, ref pos);
            Value[4] = t4;

            var t5 = new T5();
            t5.Decode(bytes, ref pos);
            Value[5] = t5;

            var t6 = new T6();
            t6.Decode(bytes, ref pos);
            Value[6] = t6;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.AddRange(t2.Encode());
            bytes.AddRange(t3.Encode());
            bytes.AddRange(t4.Encode());
            bytes.AddRange(t5.Encode());
            bytes.AddRange(t6.Encode());
            bytes.ToArray();

            Value = new Codec[7];
            Value[0] = t0;
            Value[1] = t1;
            Value[2] = t2;
            Value[3] = t3;
            Value[4] = t4;
            Value[5] = t5;
            Value[6] = t6;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

    public class Tuple<T0, T1, T2, T3, T4, T5, T6, T7> : TupleBase  where T0 : Codec, new() where T1 : Codec, new() where T2 : Codec, new() where T3 : Codec, new() where T4 : Codec, new() where T5 : Codec, new() where T6 : Codec, new() where T7 : Codec, new()
    {
        public override string TypeName() => $"({new T0().TypeName()}, {new T1().TypeName()}, {new T2().TypeName()}, {new T3().TypeName()}, {new T4().TypeName()}, {new T5().TypeName()}, {new T6().TypeName()}, {new T7().TypeName()})";

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            Value = new Codec[8];

            var t0 = new T0();
            t0.Decode(bytes, ref pos);
            Value[0] = t0;

            var t1 = new T1();
            t1.Decode(bytes, ref pos);
            Value[1] = t1;

            var t2 = new T2();
            t2.Decode(bytes, ref pos);
            Value[2] = t2;

            var t3 = new T3();
            t3.Decode(bytes, ref pos);
            Value[3] = t3;

            var t4 = new T4();
            t4.Decode(bytes, ref pos);
            Value[4] = t4;

            var t5 = new T5();
            t5.Decode(bytes, ref pos);
            Value[5] = t5;

            var t6 = new T6();
            t6.Decode(bytes, ref pos);
            Value[6] = t6;

            var t7 = new T7();
            t7.Decode(bytes, ref pos);
            Value[7] = t7;

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
        }

        public void Init(T0 t0, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7)
        {
            var bytes = new List<byte>();
            bytes.AddRange(t0.Encode());
            bytes.AddRange(t1.Encode());
            bytes.AddRange(t2.Encode());
            bytes.AddRange(t3.Encode());
            bytes.AddRange(t4.Encode());
            bytes.AddRange(t5.Encode());
            bytes.AddRange(t6.Encode());
            bytes.AddRange(t7.Encode());
            bytes.ToArray();

            Value = new Codec[8];
            Value[0] = t0;
            Value[1] = t1;
            Value[2] = t2;
            Value[3] = t3;
            Value[4] = t4;
            Value[5] = t5;
            Value[6] = t6;
            Value[7] = t7;

            TypeSize = bytes.Count;
            Bytes = bytes.ToArray();
        }
    }

}
