//
// Copyright (c) Autodesk, Inc. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//

namespace Autodesk.Forge.ARKit {

    public abstract class ForgeConstants {

        public const string ROOT ="Root" ;
        public const string ROOTPATH ="/" + ROOT ;
        public const string CAMERA ="Forge Camera" ;
        public const string CAMERAPATH ="/" + CAMERA ;
        public const string CURSOR ="Forge Cursor" ;
        public const string CURSORPATH ="/" + CURSOR ;
        public const string TOOLTIP ="Forge Tooltip" ;
        public const string TOOLTIPPATH ="/" + TOOLTIP ;
        public const string MENU ="Forge Menu" ;
        public const string MENUPATH ="/" + MENU ;
        public const string MGR ="Forge Managers" ;
        public const string MGRPATH ="/" + MGR ;
        public const string QRCODE ="QRCode" ;
        public const string QRCODEPATH =MGRPATH + "/" + QRCODE ;

        public const string INTERACTIBLE ="Interactible" ;
        public const string ENVIRONEMENT ="Environment" ;
        public const string MENUITEMS ="Menu Items" ;
        public const string IGNORERAYCASTTEMS ="Ignore Raycast" ;

        public const string _resourcesPath ="Assets/Resources/" ;
        public const string _bundlePath ="Assets/Bundles/" ;
        public const string _toolkitPath ="Assets/HoloToolkit/" ;

        public const int INIT_HOLOLENS_MENU =0 ;
        public const int IMPORT_SCENE_MENU =1 ;
        public const int BUILD_PREFAB_MENU =2 ;

    }

}