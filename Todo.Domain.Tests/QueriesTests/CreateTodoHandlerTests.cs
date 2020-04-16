using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Queries;
using Todo.Domain.Tests.Repositorios;

namespace Todo.Domain.Tests.QueriesTests
{
    [TestClass]
    public class QueriesTests
    {

        private List<TodoItem> _items;

        public QueriesTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "ivanrodfre", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "ivanrodfre", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 6", "usuario1", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 7", "usuario1", DateTime.Now));
        }


        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_do_usuario_ivanrodfre()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("ivanrodfre"));
            Assert.AreEqual(2, result.Count());
        }

    }
}
