using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbRepoGeneric.Classes;
using MongoDbRepoGeneric.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoDbRepoGeneric.Repositories
{
    public class MongoDbGenericRepository<TDocument> : IMongoDbGenericRepository<TDocument>
        where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;


        public MongoDbGenericRepository(IMongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            string collName = GetCollectionName(typeof(TDocument));
            _collection = database.GetCollection<TDocument>(collName);
        }


        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
        public IQueryable<TDocument> GetAll()
        {
            return _collection.AsQueryable();
        }

        public void DeleteDocument(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.FindOneAndDelete(filterExpression);
        }

        public Task DeleteDocumentAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => DeleteDocument(filterExpression));
        }

        public void DeleteDocumentById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            _collection.FindOneAndDelete(filter);
        }

        public Task DeleteDocumentByIdAsync(string id)
        {
            return Task.Run(() => DeleteDocumentById(id));
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            _collection.DeleteMany(filterExpression);
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => DeleteMany(filterExpression));
        }

        public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public TDocument FindDocument(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public Task<TDocument> FindDocumentAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => FindDocument(filterExpression));
        }

        public TDocument FindDocumentById(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public Task<TDocument> FindDocumentByIdAsync(string id)
        {
            return Task.Run(() => FindDocumentById(id));
        }

        public void InsertDocument(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public Task InsertDocumentAsync(TDocument document)
        {
            return Task.Run(() => InsertDocument(document));
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }

        public Task InsertManyAsync(ICollection<TDocument> documents)
        {
            return Task.Run(() => InsertMany(documents));
        }

        public void UpdateDocument(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public Task UpdateDocumentAsync(TDocument document)
        {
            return Task.Run(() => UpdateDocument(document));
        }
    }
}
