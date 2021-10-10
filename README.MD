# 「打打磚塊」遊戲手冊

<center><img src="https://raw.githubusercontent.com/YuYeh/Breakout/master/src/front_page.png" width=500 alt="font_page"/></center>

---
## 開發環境、語言
開發環境: Visual studio

語言: C#
## 遊戲模式

<center>
<img src="https://raw.githubusercontent.com/YuYeh/Breakout/master/src/easy_mode.png" width=500 alt="font_page"/>
簡單模式:單一球拍單一球，兩排磚塊，打光所有磚塊即可通關。

<img src="https://raw.githubusercontent.com/YuYeh/Breakout/master/src/normal_mode.png" width=500 alt="font_page"/>
普通模式:雙球拍、雙球、兩排磚塊，打完所有磚塊即可通關。

<img src="https://raw.githubusercontent.com/YuYeh/Breakout/master/src/hard_mode.png" width=500 alt="font_page"/>
困難模式:雙球拍、雙球、初始兩排磚塊，磚塊隨機生成。
每達一定分數獎勵球一顆，每過一定時間球拍以及球速度增加。
</center>

## 操作方式
<center>
<img src="https://raw.githubusercontent.com/YuYeh/Breakout/master/src/control1.png" width=500 alt="font_page"/>
簡單模式中，A、D建控制球板的左右移動。

<img src="https://raw.githubusercontent.com/YuYeh/Breakout/master/src/control2.png" width=500 alt="font_page"/>
普通、困難模式中，左球板由A、D鍵控制方向，右球板由方向左右鍵控制，
困難模式中，若得到獎勵球數，可點擊W(左球板)和方向上鍵(右球板)將球射出。
</center>

## 計分&失敗方式

計分方式: 每擊中一次磚塊加(1x球數)分。

失敗方式: 球數歸零或磚塊層數大於一定層數。
