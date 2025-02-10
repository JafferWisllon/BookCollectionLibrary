﻿using BookCollectionLibrary.API.Model.Base;
using BookCollectionLibrary.API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace BookCollectionLibrary.API.Repository.Generic;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private MySQLContext _context;
    private DbSet<T> _dataSet;
    public GenericRepository(MySQLContext context)
    {
        _context = context;
        _dataSet = _context.Set<T>();
    }

    public List<T> FindAll()
    {
        return _dataSet.ToList();
    }

    public T FindById(long id)
    {
        return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
    }

    public T Create(T item)
    {
        try
        {
            _dataSet.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public T Update(T item)
    {
        var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));
        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            return null;
        }
    }

    public void Delete(long id)
    {
        var result = _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        if (result != null)
        {
            try
            {
                _dataSet.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public bool Exists(long id)
    {
        return _dataSet.Any(p => p.Id.Equals(id));
    }

}
