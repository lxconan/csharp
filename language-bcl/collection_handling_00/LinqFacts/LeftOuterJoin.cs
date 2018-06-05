using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace LinqFacts
{
    /* 
     * Description
     * ===========
     * 
     * This test will implement left outer join logic using LINQ. And you should complete
     * the test in just one statement.
     * 
     * Difficulty: Medium
     * 
     * Knowledge Point
     * ===============
     * 
     * - LINQ Queries: Select, Where / join operator.
     * 
     * Requirement
     * ===========
     * 
     * - No `for`, `foreach` or other loop keywords are allowed to use.
     */
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
    public class LeftOuterJoin
    {
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        class Category
        {
            public Category(int id, string name)
            {
                Id = id;
                Name = name ?? throw new ArgumentNullException(nameof(name));
            }

            public int Id { get; }
            public string Name { get; }

            public override bool Equals(object obj)
            {
                if (obj == null) { return false; }
                if (ReferenceEquals(obj, this)) { return true; }
                if (obj.GetType() != typeof(Category)) { return false; }
                var categoryObj = (Category)obj;
                return Id == categoryObj.Id;
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Local")]
        [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Local")]
        class Product
        {
            public int Id { get; }
            public string Name { get; }
            public int CategoryId { get; }

            public Product(int id, string name, int categoryId)
            {
                Id = id;
                Name = name ?? throw new ArgumentNullException(nameof(name));
                CategoryId = categoryId;
            }

            public override bool Equals(object obj)
            {
                if (obj == null) { return false; }
                if (ReferenceEquals(obj, this)) { return true; }
                if (obj.GetType() != typeof(Product)) { return false; }
                var prodObj = (Product)obj;
                return Id == prodObj.Id;
            }

            public override int GetHashCode()
            {
                return Id.GetHashCode();
            }
        }

        class CategorisedProduct
        {
            public CategorisedProduct(string categoryName, IList<string> productNames)
            {
                CategoryName = categoryName;
                ProductNames = productNames;
            }

            public string CategoryName { get; }
            public IList<string> ProductNames { get; }

            public override bool Equals(object obj)
            {
                if (obj == null) { return false; }
                if (ReferenceEquals(obj, this)) { return true; }
                if (obj.GetType() != typeof(CategorisedProduct)) { return false; }

                var categorisedProduct = (CategorisedProduct)obj;
                return CategoryName == categorisedProduct.CategoryName &&
                    ProductNames.SequenceEqual(categorisedProduct.ProductNames, StringComparer.Ordinal);
            }

            public override int GetHashCode()
            {
                return ProductNames.Aggregate(
                    CategoryName.GetHashCode(),
                    (current, productName) => current ^ productName.GetHashCode());
            }
        }

        IEnumerable<Category> GetCategories()
        {
            return new[]
            {
                new Category(1, "Book"),
                new Category(2, "UFO"),
                new Category(3, "Toy")
            };
        }

        IEnumerable<Product> GetProducts()
        {
            return new[]
            {
                new Product(1, "Pro C#", 1),
                new Product(2, "Pro Java", 1),
                new Product(3, "Pro C++", 1),
                new Product(4, "Bear", 3),
                new Product(5, "Car", 3),
                new Product(6, "Plane", 3)
            };
        }

        #region Please modifies the code to pass the test

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static IEnumerable<CategorisedProduct> GroupProductsByCategory(
            IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        #endregion

        [Fact]
        public void should_group_products_by_category()
        {
            IEnumerable<Category> categories = GetCategories();
            IEnumerable<Product> products = GetProducts();
            IEnumerable<CategorisedProduct> grouped = GroupProductsByCategory(products, categories);

            Assert.Equal(new []
            {
                new CategorisedProduct("Book", new []{"Pro C#", "Pro Java", "Pro C++"}),
                new CategorisedProduct("UFO", Array.Empty<string>()),
                new CategorisedProduct("Toy", new []{"Bear", "Car", "Plane"})
            }, grouped);
        }
    }
}