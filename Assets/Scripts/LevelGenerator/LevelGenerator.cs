using NavMeshPlus.Components;

public class LevelGenerator : BaseMonoBeh, IService
{
    private NavMeshSurface _meshSurface;

    public override void BaseAwake()
    {
        base.BaseAwake();
    }

    public void BuildNavMesh()
    {
        _meshSurface = GetComponent<NavMeshSurface>();

        _meshSurface.BuildNavMesh();
    }
}
