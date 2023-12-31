namespace Harmony
{
	[HarmonyPatch(typeof(TileEntitySecureLootContainer))]
	[HarmonyPatch("CheckPassword")]
	public class CheckPassword
	{
		public static bool Prefix(ref bool __result, TileEntitySecureLootContainer __instance, string ___password, string _password, PlatformUserIdentifierAbs _userIdentifier)
		{
			if (!__instance.bPlayerStorage)
			{
				if (Utils.HashString(_password) == ___password)
				{
					BlockValue block = __instance.blockValue;
					BlockSecureLoot blockClass = block.Block as BlockSecureLoot;
					BlockValue blockValue2 = blockClass.LockpickDowngradeBlock;
					Vector3i vector3i = __instance.ToWorldPos();
					blockValue2 = BlockPlaceholderMap.Instance.Replace(blockValue2, GameManager.Instance.World.GetGameRandom(), vector3i.x, vector3i.z, false);
					blockValue2.rotation = block.rotation;
					blockValue2.meta = block.meta;
					GameManager.Instance.World.SetBlockRPC(__instance.GetClrIdx(), vector3i, blockValue2, blockValue2.Block.Density);
					__result = true;
					return false;
				}
			}
			return true;
		}
	}
	[HarmonyPatch(typeof(BlockSecureLoot))]
	[HarmonyPatch("OnBlockAdded")]
	public class OnBlockAdded
	{
		public static void Postfix(WorldBase world, Chunk _chunk, Vector3i _block	Pos, BlockValue _blockValue)
		{
			if (world.GetTileEntity(_chunk.ClrIdx, _blockPos) is TileEntitySecureLootContainer te)
			{
				PlatformUserIdentifierAbs internalLocalUserIdentifier = PlatformManager.InternalLocalUserIdentifier;
				te.SetOwner(internalLocalUserIdentifier);
				int pass = UnityEngine.Random.Range(00000001, 99999999);
				NGUIDebug.Log(pass);
				te.CheckPassword(pass.ToString(), internalLocalUserIdentifier, out bool flag);
				te.SetOwner(null);
				te.bPlayerStorage = false;
			}
		}
	}
}
