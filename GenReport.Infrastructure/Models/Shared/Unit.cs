using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.Infrastructure.Models.Shared
{
    

    /// <summary>
    /// Represents a void type, typically used in generic contexts where a type must be provided
    /// but no value is actually needed or returned.
    /// </summary>
    public readonly struct Unit : IEquatable<Unit>
    {
        /// <summary>
        /// The single instance of the Unit type.
        /// </summary>
        public static readonly Unit Value = new Unit();

        /// <summary>
        /// Determines whether the specified Unit is equal to the current Unit.
        /// </summary>
        /// <param name="other">The Unit to compare with the current Unit.</param>
        /// <returns>true if the specified Unit is equal to the current Unit; otherwise, false.</returns>
        public bool Equals(Unit other) => true;

        /// <summary>
        /// Determines whether the specified object is equal to the current Unit.
        /// </summary>
        /// <param name="obj">The object to compare with the current Unit.</param>
        /// <returns>true if the specified object is a Unit; otherwise, false.</returns>
         #pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj) => obj is Unit;
        #pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).

        /// <summary>
        /// Returns the hash code for this Unit.
        /// </summary>
        /// <returns>A hash code for the current Unit.</returns>
        public override int GetHashCode() => 0;

        /// <summary>
        /// Returns a string that represents the current Unit.
        /// </summary>
        /// <returns>A string that represents the current Unit.</returns>
        public override string ToString() => "()";

        /// <summary>
        /// Determines whether two Unit instances are equal.
        /// </summary>
        public static bool operator ==(Unit left, Unit right) => true;

        /// <summary>
        /// Determines whether two Unit instances are not equal.
        /// </summary>
        public static bool operator !=(Unit left, Unit right) => false;
    }
}
