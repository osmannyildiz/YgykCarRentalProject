﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete {
    public class CustomerManager : ICustomerService {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal) {
            _customerDal = customerDal;
        }

        public IResult Add(Customer entity) {
            _customerDal.Add(entity);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer entity) {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter) {
            return new SuccessDataResult<Customer>(_customerDal.Get(filter));
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null) {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(filter));
        }

        public IResult Update(Customer entity) {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
