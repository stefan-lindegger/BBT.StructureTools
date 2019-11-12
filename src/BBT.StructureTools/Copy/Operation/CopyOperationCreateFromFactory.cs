﻿namespace BBT.StructureTools.Copy.Operation
{
    using System;
    using System.Linq.Expressions;
    using BBT.StructureTools.Copy;
    using BBT.StructureTools.Extension;
    using BBT.StructureTools.Initialization;

    /// <inheritdoc/>
    internal class CopyOperationCreateFromFactory<T, TValue, TAttributeValueFactory> : ICopyOperationCreateFromFactory<T, TValue, TAttributeValueFactory>
        where T : class
        where TAttributeValueFactory : class
    {
        private Expression<Func<T, TValue>> targetexpression;

        private Func<TAttributeValueFactory, TValue> attrValueFunc;

        private TAttributeValueFactory attributeValueFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyOperationCreateFromFactory{T, TValue, TAttributeValueFactory}"/> class.
        /// </summary>
        public CopyOperationCreateFromFactory()
        {
        }

        /// <inheritdoc/>
        public void Copy(T source, T target, ICopyCallContext copyCallContext)
        {
            var value = this.attrValueFunc.Invoke(this.attributeValueFactory);
            target.SetPropertyValue(this.targetexpression, value);
        }

        /// <inheritdoc/>
        public void Initialize(Expression<Func<T, TValue>> targetExpression, Expression<Func<TAttributeValueFactory, TValue>> aAttrValueExpression)
        {
            targetExpression.NotNull(nameof(targetExpression));
            aAttrValueExpression.NotNull(nameof(aAttrValueExpression));

            var attributeValueFactory = IocHandler.Instance.IocResolver.GetInstance<TAttributeValueFactory>();
            attributeValueFactory.NotNull(nameof(attributeValueFactory));

            this.attributeValueFactory = attributeValueFactory;
            this.attrValueFunc = aAttrValueExpression.Compile();
            this.targetexpression = targetExpression;
        }
    }
}