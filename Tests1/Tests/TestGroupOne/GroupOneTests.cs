using System;
using System.Collections.Generic;
using System.Text;
using Tests1.Hooks;

namespace Tests1.Tests.TestGroupOne
{
    [TestFixture]
    //теги (aka attributes) про параллельному прогону, которые вешаются на фикстуры
    //[Parallelizable(ParallelScope.Fixtures)] //параллельно ходят фикстуры, а тесты в них последовательно
    //[Parallelizable(ParallelScope.Children)] //фикстуры идут последовательно, но тесты в них параллельно
    //[Parallelizable(ParallelScope.All)] // параллельно идут и фикстуры, и тесты
    //[Parallelizable] // параллельно идут и фикстуры, и тесты
    public class GroupOneTests : HooksForTestGroup
    {
        [Test]
        //[Timeout(30000)] // тег лимита времени для теста в мс. Тест будет красный, если не успеет пройти за указанное время (даже если прошел)
        //[Parallelizable(ParallelScope.Self)] // тест может идти параллельно с другими тестами, но не могут идти параллельно с параметризованными тестами
        //[Repeat(3)] // повторить тест до Х раз, если упал. Тест упал - запуститтся еще раз. Упал Х раз - тест красный
        //[Category("Smoke")] // назначает категорию тесту
        //[Order(1)] // задавать порядок запуска, но это очень нестабильная история + в идеале тесты не должны зависеть от порядка запуска
        //[Description("leave test desc here")] // описание теста. Репорты могту подхватывать это описание
        //[Ignore("просто потому что")] // тест не будет запускаться
        public void Test001()
        {
            //Assert.IsTrue(true);
        }
    }
}
