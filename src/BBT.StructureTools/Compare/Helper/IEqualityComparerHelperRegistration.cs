﻿namespace BBT.StructureTools.Compare.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// Helper for the equals and get hash code calculation.
    /// </summary>
    /// <typeparam name="T">Class to compare.</typeparam>
    public interface IEqualityComparerHelperRegistration<T>
        where T : class
    {
        /// <summary>
        /// Register a compare attribute of type <typeparamref name="TValue"/>.
        /// </summary>
        /// <typeparam name="TValue">The type of the attribute to compare.</typeparam>
        IEqualityComparerHelperRegistration<T> RegisterAttribute<TValue>(Expression<Func<T, TValue>> expression);

        /// <summary>
        /// See <see cref="RegisterAttributeWithDistinguishedComparer{TTargetModel,TIntention}"/>.
        /// </summary>
        /// <typeparam name="TComparer">Type of model-comparer"/>.</typeparam>
        /// <typeparam name="TIntention">The compare intention.</typeparam>
        IEqualityComparerHelperRegistration<T> RegisterAttributeWithDistinguishedComparer<TComparer, TIntention>(
            Expression<Func<T, TComparer>> expression,
            IComparer<TComparer, TIntention> comparer)
            where TComparer : class
            where TIntention : IBaseComparerIntention;

        /// <summary>
        /// Register a to many relationship.
        /// </summary>
        /// <typeparam name="TComparer">Type of combined-comparer"/>.</typeparam>
        /// <typeparam name="TComparerIntention">The comparer intention.</typeparam>
        IEqualityComparerHelperRegistration<T> RegisterToManyRelationship<TComparer, TComparerIntention>(
            Expression<Func<T, IEnumerable<TComparer>>> expression,
            IComparer<TComparer, TComparerIntention> comparer)
            where TComparer : class
            where TComparerIntention : IBaseComparerIntention;

        /// <summary>
        /// Register a sub compare for a base class or a implemented interface.
        /// </summary>
        /// <typeparam name="TComparerIntention">The comparer intention.</typeparam>
        IEqualityComparerHelperRegistration<T> RegisterSubCompare<TComparerIntention>(
            IComparer<T, TComparerIntention> comparer)
            where TComparerIntention : IBaseComparerIntention;

        /// <summary>
        /// Ends the registrations and start the operation phase.
        /// </summary>
        IEqualityComparerHelperOperations<T> EndRegistrations();
    }
}