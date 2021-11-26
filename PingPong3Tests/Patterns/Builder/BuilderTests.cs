using Xunit;
using Moq;
using PingPong3.Patterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingPong3.Forms;

namespace PingPong3.Patterns.Builder.Tests
{
    public class BuilderTests
    {
        [Fact()]
        public void ClassicLevelDataNotNull()
        {
            LevelBuilder builder = new ClassicLevelBuilder();
            new LevelDirector().ConstructWalls(builder);
            Assert.NotNull(builder.GetResult());
        }

        [Fact()]
        public void AdvancedLevelDataNotNull()
        {
            LevelBuilder builder = new AdvancedLevelBuilder();
            new LevelDirector().ConstructWalls(builder);
            Assert.NotNull(builder.GetResult());
        }

        [Fact()]
        public void FrenzyLevelDataNotNull()
        {
            LevelBuilder builder = new FrenzyLevelBuilder();
            new LevelDirector().ConstructWalls(builder);
            Assert.NotNull(builder.GetResult());
        }

        [Fact()]
        public void ClassicLevelDataWallCount()
        {
            LevelBuilder builder = new ClassicLevelBuilder();
            new LevelDirector().ConstructWalls(builder);
            Assert.Empty(builder.GetResult().walls);
        }

        [Fact()]
        public void AdvancedLevelDataWallCount()
        {
            LevelBuilder builder = new AdvancedLevelBuilder();
            new LevelDirector().ConstructWalls(builder);
            Assert.Equal(4, builder.GetResult().walls.Count);
        }

        [Fact()]
        public void FrenzyLevelDataWallCount()
        {
            LevelBuilder builder = new FrenzyLevelBuilder();
            new LevelDirector().ConstructWalls(builder);
            Assert.Equal(28, builder.GetResult().walls.Count);
        }
    }
}
