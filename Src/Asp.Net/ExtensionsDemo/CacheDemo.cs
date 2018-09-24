﻿using SqlSugar;
using SqlSugar.Extensions;
using System;
using System.Linq;

namespace ExtensionsDemo
{
    public class CacheDemo
    {
        public static void Init()
        {
            //HttpRuntimeCache();
            RedisCache();

        }

        private static void HttpRuntimeCache()
        {
            ICacheService myCache = new HttpRuntimeCache();//ICacheService


            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    DataInfoCacheService = myCache //Setting external cache service
                }
            });


            for (int i = 0; i < 10000; i++)
            {
                db.Queryable<Student>().Where(it => it.Id > 0).WithCache().ToList();
            }


            db.Queryable<Student, Student>((s1, s2) => s1.Id == s2.Id).Select(s1 => s1).WithCache().ToList();


            db.Queryable<Student, Student>((s1, s2) => new object[] {
                JoinType.Left,s1.Id==s2.Id
            }).Select(s1 => s1).WithCache().ToList();


            Console.WriteLine("Cache Key Count:" + myCache.GetAllKey<string>().Count());

            foreach (var item in myCache.GetAllKey<string>())
            {
                Console.WriteLine();
                Console.WriteLine(item);
                Console.WriteLine();
            }

            db.Deleteable<Student>().Where(it => it.Id == 1).RemoveDataCache().ExecuteCommand();

            Console.WriteLine("Cache Key Count:" + myCache.GetAllKey<string>().Count());
        }
        private static void RedisCache()
        {
            ICacheService myCache = new RedisCache("10.1.249.196");//ICacheService
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    DataInfoCacheService = myCache //Setting external cache service
                }
            });


            db.Queryable<Student>().Where(it => it.Id > 0).WithCache(30).ToList();

            db.Queryable<Student, Student>((s1, s2) => s1.Id == s2.Id).Select(s1 => s1).WithCache(30).ToList();


            db.Queryable<Student, Student>((s1, s2) => new object[] {
                JoinType.Left,s1.Id==s2.Id
            }).Select(s1 => s1).WithCache(30).ToList();


            Console.WriteLine("Cache Key Count:" + myCache.GetAllKey<string>().Count());

            foreach (var item in myCache.GetAllKey<string>())
            {
                Console.WriteLine();
                Console.WriteLine(item);
                Console.WriteLine();
            }

            db.Deleteable<Student>().Where(it => it.Id == 1).RemoveDataCache().ExecuteCommand();

            Console.WriteLine("Cache Key Count:" + myCache.GetAllKey<string>().Count());
        }
    }
}
