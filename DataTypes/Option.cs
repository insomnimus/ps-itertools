using System;

namespace Itertools.DataTypes;

public struct Option<T> {
	public Option() => (this.val, this.IsSome) = (default(T), false);
	public Option(T val) => (this.val, this.IsSome) = (val, true);

	public bool IsSome { get; private set; }
	public bool IsNone => !this.IsSome;
	private T val;

	public static Option<T> None => new Option<T>();
	public static Option<T> Some(T val) => new Option<T>(val);
	public static implicit operator Option<T>(T val) => new Option<T>(val);

	public Option<O> Map<O>(Func<T, O> map) {
		if (this.IsNone) return Option<O>.None;
		else return map(this.val);
	}

	public void Map(Action<T> map) {
		if (this.IsSome) map(this.val);
	}
}
