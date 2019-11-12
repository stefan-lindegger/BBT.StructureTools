﻿namespace BBT.StructureTools.Copy.Operation
{
    using System;
    using System.Linq.Expressions;
    using BBT.StructureTools.Copy;
    using BBT.StructureTools.Extension;

    /// <inheritdoc/>
    internal class CopyOperationCreateToOneWithReverseRelation<T, TChild, TConcreteChild> : ICopyOperationCreateToOneWithReverseRelation<T, TChild, TConcreteChild>
        where T : class
        where TChild : class
        where TConcreteChild : class, TChild, new()
    {
        private Func<T, TChild> sourceFunc;

        private Expression<Func<T, TChild>> targetexpression;

        private ICreateCopyHelper<TChild, TConcreteChild, T> createCopyHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyOperationCreateToOneWithReverseRelation{T, TChild, TConcreteChild}"/> class.
        /// </summary>
        public CopyOperationCreateToOneWithReverseRelation()
        {
        }

        /// <inheritdoc/>
        public void Initialize(
            Func<T, TChild> sourceFunc,
            Expression<Func<T, TChild>> targetFuncExpr,
            ICreateCopyHelper<TChild, TConcreteChild, T> aCreateCopyHelper)
        {
            aCreateCopyHelper.NotNull(nameof(aCreateCopyHelper));
            sourceFunc.NotNull(nameof(sourceFunc));
            targetFuncExpr.NotNull(nameof(targetFuncExpr));

            this.targetexpression = targetFuncExpr;
            this.sourceFunc = sourceFunc;
            this.createCopyHelper = aCreateCopyHelper;
        }

        /// <inheritdoc/>
        public void Copy(
            T source,
            T target,
            ICopyCallContext copyCallContext)
        {
            source.NotNull(nameof(source));
            target.NotNull(nameof(target));
            copyCallContext.NotNull(nameof(copyCallContext));

            var sourceChild = this.sourceFunc.Invoke(source);

            // if the source is null, set the target also to null and exit copy process step.
            if (sourceChild == null)
            {
                target.SetPropertyValue(this.targetexpression, null);
                return;
            }

            var sourceConcrete = sourceChild as TConcreteChild;
            sourceConcrete.NotNull(nameof(sourceConcrete));

            var copy = this.createCopyHelper.CreateTarget(
                sourceConcrete,
                target,
                copyCallContext);

            target.SetPropertyValue(this.targetexpression, copy);
        }
    }
}