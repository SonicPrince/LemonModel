## 这是Lemon游戏框架的打包管理器部分

###### 打包管理器已经实现：

- 加载规则
- 根据规则标记资源，并进行打包

###### 打包规则定义文件如buildrules.txt内容所示：

```
Prefab/Role#	.prefab#	../../../Lemon_assetsdata/model
Prefab/Scene#	.prefab#	../../../Lemon_assetsdata/model
```
###### 可以配置若干规则，每个规则含义为：Prefab/Role为该路径下所有.prefab资源，打包到../../../Lemon_assetsdata/model目录下


==客户端的框架见 github.com/SonicPrince/LemonClient==
