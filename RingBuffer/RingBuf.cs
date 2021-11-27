using System;
using System.Collections;
using System.Collections.Generic;

namespace Itertools.RingBuffer {
	public class RingBuf<T>: IEnumerable<T> {
		public int Capacity { get; private set; }
		// Head is always where the element should be written.
		// If tail == head the buffer is empty.
		private int head = 0;
		private int tail = 0;
		public int Count => buf.Count;
		private List<T> buf;

		public T this[int index] {
			get {
				return buf[getIndex(index)];
			}
			set {
				buf[getIndex(index)] = value;
			}
		}

		public RingBuf(int cap) {
			if (cap <= 0) {
				throw new Exception("the value for capacity must be above 0");
			}
			Capacity = cap;
			// Do not pre-allocate.
			buf = new List<T>() { };
		}

		private int getIndex(int index) {
			if (index > Count || index < 0) {
				throw new IndexOutOfRangeException($"the index is {index} but the length is {Count}");
			} else {
				var n = tail + index;
				if (n >= Count) {
					n -= Count;
				}
				return n;
			}
		}

		public void Push(T item) {
			if (Count < Capacity) {
				buf.Add(item);
			} else {
				buf[head] = item;
				tail++;
				if (tail >= Capacity) {
					tail = 0;
				}
			}
			head++;
			if (head >= Capacity) {
				head = 0;
			}
		}

		public IEnumerator<T> GetEnumerator() {
			for (int i = 0; i < Count; i++) {
				yield return this[i];
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}
}
