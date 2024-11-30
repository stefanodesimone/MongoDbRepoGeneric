using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbRepoGeneric.Interfaces
{
    public interface IMongoDbGenericRepository<TDocument> where TDocument : IDocument
    {
        /// <summary>
        /// To get all documents.
        /// </summary>
        IQueryable<TDocument> GetAll();
        /// <summary>
        /// To get all documents by filter.
        /// </summary>
        IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression);
        /// <summary>
        /// To get a document by filter and project.
        /// </summary>
        IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);
        /// <summary>
        /// To get document by filter.
        /// </summary>
        TDocument FindDocument(Expression<Func<TDocument, bool>> filterExpression);
        /// <summary>
        /// To get document by filter.
        /// </summary>
        Task<TDocument> FindDocumentAsync(Expression<Func<TDocument, bool>> filterExpression);
        /// <summary>
        /// To get a document by id asynchronously.
        /// </summary>
        TDocument FindDocumentById(string id);
        /// <summary>
        /// To get a document by id asynchronously.
        /// </summary>
        Task<TDocument> FindDocumentByIdAsync(string id);
        /// <summary>
        /// To insert a new document.
        /// </summary>
        void InsertDocument(TDocument document);
        /// <summary>
        /// To insert a new document asynchronously.
        /// </summary>
        Task InsertDocumentAsync(TDocument document);
        /// <summary>
        /// To insert many new documents.
        /// </summary>
        void InsertMany(ICollection<TDocument> documents);
        /// <summary>
        /// To insert many new documents asynchronously.
        /// </summary>
        Task InsertManyAsync(ICollection<TDocument> documents);
        /// <summary>
        /// To update a document.
        /// </summary>
        void UpdateDocument(TDocument document);
        /// <summary>
        /// To update a document asynchronously.
        /// </summary>
        Task UpdateDocumentAsync(TDocument document);
        /// <summary>
        /// To delete a document by filter.
        /// </summary>
        void DeleteDocument(Expression<Func<TDocument, bool>> filterExpression);
        /// <summary>
        /// To delete a document  by filter asynchronously.
        /// </summary>
        Task DeleteDocumentAsync(Expression<Func<TDocument, bool>> filterExpression);
        /// <summary>
        /// To delete a document by id.
        /// </summary>
        void DeleteDocumentById(string id);
        /// <summary>
        /// To delete a document by id asynchronously.
        /// </summary>
        Task DeleteDocumentByIdAsync(string id);
        /// <summary>
        /// To delete many documents by filter.
        /// </summary>
        void DeleteMany(Expression<Func<TDocument, bool>> filterExpression);
        /// <summary>
        /// To delete many documents by filter asynchronously.
        /// </summary>
        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}
