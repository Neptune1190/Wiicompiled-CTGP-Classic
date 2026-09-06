namespace WiiCompiled.Setup.Windows;

internal static class CtgpClassicSource
{
    public static string Resolve(string directory)
    {
        var root = Path.GetFullPath(directory);
        if (HasCodePul(root)) return root;

        var nested = Path.Combine(root, "ctgpclassic");
        if (HasCodePul(nested)) return nested;

        throw new InvalidDataException(
            "The CTGP Classic folder must contain Binaries\\CodeR.pul, either directly or under ctgpclassic.");
    }

    public static string ResolveRiivolutionRoot(string packageRoot)
    {
        var parent = Directory.GetParent(packageRoot)?.FullName
                     ?? throw new InvalidDataException("The CTGP Classic folder has no parent directory.");
        var sibling = Path.Combine(parent, "Riivolution");
        if (!File.Exists(Path.Combine(sibling, "ctgpclassic.xml")))
            throw new InvalidDataException(
                "The CTGP Classic package requires a sibling Riivolution\\ctgpclassic.xml.");
        return sibling;
    }

    private static bool HasCodePul(string root) =>
        Directory.Exists(root) && File.Exists(Path.Combine(root, "Binaries", "CodeR.pul"));
}