﻿namespace BBT.StructureTools.Extension
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Common runtime checks that throw <see cref="ArgumentException"/> upon failure.
    /// </summary>
    internal static class StructureToolsArgumentChecks
    {
        /// <summary>
        /// Throws an exception if the specified parameter's value is null.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        [DebuggerStepThrough]
        internal static void NotNull<T>([ValidatedNotNull]this T value, string parameterName)
            where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is null, empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is empty or consists only of white-space characters.</exception>
        [DebuggerStepThrough]
        internal static void NotNullOrWhiteSpace([ValidatedNotNull]this string value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is negative.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative.</exception>
        [DebuggerStepThrough]
        internal static void NotNegative(this int value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is negative or zero.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> is negative or zero.</exception>
        [DebuggerStepThrough]
        internal static void NotNegativeOrZero(this int value, string parameterName)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        [DebuggerStepThrough]
        internal static void NotNullOrEmpty<T>(this IEnumerable<T> value, string parameterName)
        {
            // ReSharper disable once PossibleMultipleEnumeration
            value.NotNull(parameterName);

            // ReSharper disable once PossibleMultipleEnumeration
            if (!value.Any())
            {
                throw new ArgumentException("Empty list.", parameterName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is null or empty.
        /// </summary>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        [DebuggerStepThrough]
        internal static void NotNullOrEmpty(this string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Empty list.", parameterName);
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is null, empty or contains an empty element.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> contains an empty element.</exception>
        [DebuggerStepThrough]
        internal static void NotNullOrEmptyElement<T>(this IEnumerable<T> value, string parameterName)
        {
            // ReSharper disable once PossibleMultipleEnumeration
            value.NotNull(parameterName);

            // ReSharper disable once PossibleMultipleEnumeration
            if (value.Any(x => x == null))
            {
                throw new ArgumentOutOfRangeException(parameterName, "List contains.");
            }
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is null, empty or contains an empty element.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The value of the argument.</param>
        /// <param name="parameterName">The name of the parameter to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="value"/> contains an empty element.</exception>
        [DebuggerStepThrough]
        internal static void NotNullOrEmptyOrEmptyElement<T>(this IEnumerable<T> value, string parameterName)
        {
            // ReSharper disable once PossibleMultipleEnumeration
            value.NotNullOrEmpty(parameterName);

            // ReSharper disable once PossibleMultipleEnumeration
            value.NotNullOrEmptyElement(parameterName);
        }

        /// <summary>
        /// Throws an exception if the specified parameter's value is null, or not of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The expected type of the parameter.</typeparam>
        /// <param name="value">The object which is checked.</param>
        /// <param name="objName">The name of the object variable to include in any thrown exception.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidCastException">Thrown if <paramref name="value"/> is not of type <typeparamref name="T"/>.</exception>
        [DebuggerStepThrough]
        internal static void IsOfType<T>(this object value, string objName)
        {
            value.NotNull(objName);

            if (value is T)
            {
                return;
            }

            throw new InvalidCastException(FormattableString.Invariant($"{objName} isn't of type {typeof(T)}."));
        }
    }
}