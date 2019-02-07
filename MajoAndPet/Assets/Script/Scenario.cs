﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario {
    public static string Username;

    public string[][] GetAllScenario(int index)
    {
        string[][] tempStorage = new string[][] { Narration[index], Majo[index], Mobs[index], Mao[index] };
        return tempStorage;
    }
    public int[] GetNagare(int index)
    {
        return ChatNagare[index];
    }
    public int[] GetRepeat(int index)
    {
        return RepeatTime[index];
    }
    public string[] GetCharName(int index)
    {
        return CharName[index];
    }
    public string[] GetMobsName(int index)
    {
        return MobsName[index];
    }

    public int[] GetStep(int index)
    {
        return transformStep[index];
    }
    public int[] GetEntry(int index)
    {
        return MiniGameEntry[index];
    }
    private string[][] MobsName = new string[][] { new string[] { "？？？", "ドラゴンの子供", "フィデス" },
                                                      new string[] { "？？？", "グリフォンの子供", "インテゲル" },
                                                      new string[] { "子犬", "オオカミの子供", "オオカミ", "モルゲン", "オオカミ", "モルゲン" } };

    private int[][] transformStep = new int[][]
    {
        new int[] { 1, 6 },
        new int[] { 2, 6 },
        new int[] { 1, 2,5, 7,16 }
    };
    private int[][] MiniGameEntry = new int[][]
    {
        new int[] { 78 ,137},
         new int[] { 69, -1 },
          new int[] { -1, -1 }
    };
    private int[][] ChatNagare = new int[][] {
    new int[]
    {
        1,0,1,2,1,0,1,0,1,0,3,1,0,1,0,1,0,2,1,0,2,1,
        0,1,2,0,1,0,1,0,1,0,1,2,1,0,1,2,1,0,1,0,1,2,
        1,0,1,0,2,1,2,1,2,0,1,2,1,0,1,0,1,2,1,0,1,2,
        0,1,0,1,0,1,0,2,1,2,1,0,2,1,2,1,2,0,1,0,1,0,
        1,0,2,1,0,1,0,1,2,0,2,1,2,1,0,1,2,1,0,1,2,1,
        2,1,0,2,1,0,2,0,1,0,2,0,1,2,0,2,1,2,0,1,2,0,
        1,2,1,2,1,0,2,0,1,0,1,2,0,2,0,1,0,1,2,0,-1
    },
    new int[]
    {
        1,0,1,2,1,0,2,1,0,1,0,2,1,0,3,
        1,0,2,0,1,2,0,1,0,2,0,1,0,1,2,
        0,2,1,2,0,1,2,1,2,1,2,1,0,1,2,
        0,1,2,0,1,2,1,2,1,0,1,0,1,2,0,
        1,2,0,1,2,1,0,2,0,1,2,1,2,1,0,
        1,0,1,0,1,0,1,0,1,0,1,0,1,0,2,
        0,1,0,2,1,0,1,2,0,2,0,1,0,1,2,
        0,2,1,2,1,0,2,0,2,1,2,1,2,0,2,
        0,1,2,0,2,1,0,2,1,0,1,0,2,0,2,
        0,2,1,0,1,0,2,0,1,2,0,2,1,0,1,
        0,1,0,2,0,1,0,-1
    },
    new int[]
    {
        1,0,1,0,1,0,1,2,0,1,0,3,1,0,1,0,1,0,2,1,0,2,0,1,0,1,0,1,0,1,2,0,1,
        2,0,1,0,1,0,1,0,1,0,1,0,2,0,1,2,0,1,0,1,0,2,0,2,0,2,1,2,0,1,0,2,1,
        2,1,2,1,2,1,2,0,1,0,1,0,1,0,1,0,1,2,1,0,1,2,1,2,0,1,0,1,0,1,0,1,0,
        1,0,1,2,0,2,1,2,1,2,1,2,1,0,1,2,1,0,2,1,2,0,1,0,1,2,0,2,1,2,1,2,0,
        2,0,1,0,2,1,0,2,1,0,2,-1
    }
    };
    private int[][] RepeatTime = new int[][] {
    new int[]
    {
        1,1,2,1,1,1,1,1,1,1,6,2,1,2,1,1,1,1,1,2,1,1,
        1,1,1,1,1,1,1,1,1,2,1,1,2,2,1,1,1,1,3,1,1,1,
        1,2,1,2,1,2,1,1,1,1,1,1,1,1,2,2,2,1,1,3,1,1,
        1,1,5,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,8,1,3,
        2,1,1,1,5,1,2,1,1,1,1,1,1,1,2,1,7,1,1,3,1,1,
        1,2,4,1,1,2,1,5,1,2,1,1,2,1,1,1,1,1,1,1,1,2,
        2,1,2,1,1,3,1,1,1,2,1,1,1,2,1,1,1,1,3,1
    },
    new int[]
    {
        1,1,1,1,2,1,1,1,2,1,1,1,1,2,6,
        3,1,1,1,1,1,1,1,1,1,1,1,2,1,1,
        1,1,1,1,3,2,1,1,1,1,1,1,1,2,1,
        1,2,1,6,1,1,1,2,1,4,1,1,1,1,1,
        1,1,5,1,1,1,2,1,1,1,2,1,3,1,1,
        1,1,1,2,2,2,1,1,1,2,1,1,4,3,1,
        1,1,1,1,1,1,1,1,2,1,1,3,1,1,1,
        2,1,1,7,1,1,5,1,1,1,1,1,2,4,1,
        1,2,1,3,1,1,1,1,1,1,1,1,1,1,3,
        1,2,1,1,1,1,1,1,1,2,1,1,1,1,1,
        1,2,1,1,1,2,1
    },
    new int[]
    {
        1,1,4,1,1,2,1,1,2,1,3,6,2,1,1,2,1,3,1,2,3,1,2,1,1,1,1,1,1,2,1,3,1,
        1,1,1,3,1,3,1,1,2,1,1,1,1,2,1,1,6,1,8,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
        1,1,1,1,1,1,1,5,1,3,1,1,1,2,1,1,1,1,2,2,1,1,1,1,2,1,6,1,3,1,1,1,4,
        1,1,2,1,3,1,1,2,1,3,3,1,1,1,3,1,2,1,1,1,2,4,1,2,1,1,1,5,2,1,1,1,2,
        1,2,1,2,1,2,3,3,3,1,2
    }
    };
    private string[][] CharName = new string[][]
    {
        new string[] { "", Username, "フィデス", "魔王フェルス" },
        new string[] { "", Username, "インテゲル", "魔王フェルス" },
        new string[] { "", Username, "モルゲン", "魔王フェルス" }
    };
    
    private string[][] Narration = new string[][]
    {
         new string[] //Narration
    {
        "気持ちのいい昼下がり。\n薬草の世話をするために温室に入ると、\n見るからに怪しいダンボールが鎮座していた。",
        "ダンボールの隅っこには\n幼いドラゴンがぐったりと横たわっていた。",
        "それにしても、幼いドラゴンは何を食べるの？\n困り果てているわたしは、\n左手にある手紙とにらみっこをし始めた。",
        "手紙の内容をまとめると――",
        "紙に書かれた通り食べ物を用意し\n再び温室に戻ってくると、ドラゴンは\n相変わらず弱々しい呼吸を繰り返している。",
        "しかし何度呼びかけても、\nその子は微動だにしない。\nもしかしたら食べる気力もないのかな。",
        "だとすれば食べさせるしかない、\nそう思い、わたしはその子に手を伸ばした。",
        "怒ったのか、その子はこっちに向けて\n青い炎を吐き出した。",
        "勢いこそ小さいけれど、\n距離が近かったせいで\n指先がしっかりやけどをしてしまった。",
        "小さくても言葉はわかるのか、\nその子はやっとわたしのほうを\nジーと見つめてきた。",
        "数歩下がったわたしを見て、\nその子はやはり警戒深く、\n恐る恐る皿に鼻を寄せた。",
        "そう言うと、またその子は\nジーとわたしを睨みつけた。",
        "ドラゴンの食べ物はお世辞でも\n魔女の口に合うはずもなかった。",
        "ある種の毒味が功を奏したか、\nもぐもぐと、\nその子はやっとごはんに口をつけた。",
        "数分後。",
        "焦っていると、\nその子は自らダンボールを抜け\nトボトボとわたしの足元までやってきた。",
        "うずくまっているわたしが首をかしげると、\nその子はぶら下がっているわたしの指先に\nためらいながら顔を寄せた。",
        "恐る恐るその背中に触れてみる。\n身体こそこわばったけど、\n今度は拒絶されなかった。",
        "数週間後。",
        "あれから改めてお兄ちゃんに聞くと、\nこれが勢力拡大の一環だと教えてもらった。",
        "魔獣の心の傷を癒して\nもとの様子に戻してあげるという。",
        "あれからちゃんとごはんを食べて、\nドラゴンはやっと少し話せるようになり、名前も教えてくれた。",
        "ただ記憶があいまいで\nここに来る以前のことは\nあまり思い出せないらしい。",
        "二人でベッドに並んで、\nフィデスの小さなおでこに\n自分のおでこを合わせた。",
        "彼の温度を持たない身体を抱きしめ、\nなるべく優しく、\n柔らかく言葉を紡ぐ。",
        "眠りの世界に落ちていく彼にかけた魔法、\nそれは彼の記憶と\n彼の心を取り戻すための魔法だった。",
        "数週間後。",
        "突如襲ってくる暴風に\n思わず目をぎゅっとつむった。",
        "再び目を開けるとき、\nわたしよりずっと高くて大きい\n美しいドラゴンの姿が目の前にあった。",
        "そうだ、この元の気高き姿を\n取り戻したドラゴンこそが――フィデスだ。",
        "初めて二人で眠りについた夜、\n朝になり、私は暴力的な騒音によって起こされた。",
        "目を開けると部屋はもうぐちゃぐちゃになって、\n大きなドラゴンがその金色の瞳で、\n私に助けを求めた。",
        "だって、その夜に\nわたしは彼に一つ「心をほどく魔法」をかけた。",
        "お兄ちゃんがくれた手紙によると、\nこれで魔獣は少しずつ\n記憶を取り戻すことができる。",
        "記憶と共に、姿も小さい頃のものから\n元に戻れるという。さすがに\nそこまで劇的な変化は予想できなかったけれど。",
        "幸い、この小屋は魔法の産物で\nすぐに修繕できたけれど。",
        "そう告げても、物思いにふけているらしく\nフィデスは何も答えてくれない。\nただ遠いどこかをずっと見つめている。",
        "あの日から、彼は度々こうなってしまう。\nその頻度も、最近では\nかなり増えている気がする。",
        "思わず心配になって近寄り\n彼の大きな金色の瞳を覗き込むと、\nびっくりしたのか少しうろたえ、慌てて離れた。",
        "小さかった頃の名残なのか、\nこうして名前を呼ぶと\n彼はわたしの話を聞いてくれる。",
        "それきり、彼は口を閉ざしてしまい\nもうこれ以上は教えてくれないらしい。\nたぶん、楽しい思い出じゃないのだろう。",
        "フィデスの頭を抱きしめようとして、\nけれど抱えきれなくて、\nそれでも硬い鱗片を撫でてあげた。",
        "不服そうに息をついても\n彼はわたしを拒まなかった。",
        "それがなんだかくすぐったくて…\n形こそ大きくなったけれど、\nあの小さかったドラゴンは確かにここにいる。",
        "――そんな風に、\n全てうまくいくと\nわたしは甘く考えていた。",
        "フィデスが思い悩む時間か\n日に日に増えていって、\nわたしとも口を利かなくなってきた。",
        "ごはんを持っていっても\n姿すら見せない日だってある。",
        "どうしたらいいと\n焦る気持ちでいっぱいだけれど、\nわたしに何ができるのか、わからなかった。",
        "そして、ついに三日ほど彼の姿を見ていない\nその日の夜に――",
        "夜の温室はひどく静かで、暗くて\n今日は特に、何か得体のしれないものを\nはらんでいるようにも感じる。",
        "魔獣の傷を癒す、確かにそれはお兄ちゃんに\n頼まれた仕事だけれど、そうでなくとも、\nわたしは純粋に彼のことが心配だ。",
        "ちゃんと話をしなきゃ、\nそう思って来てみたけれど\n彼は出てきてくれるだろうか。",
        "わたしの声だけが、\nだだっ広い空間にむなしく響く。",
        "振り向けば、夜空に包まれた天井の近くに\nフィデスはゆるやかに羽ばたき、\n上空からわたしを見降ろしていた。",
        "このものものしい雰囲気のせいか\nその立派な角も、整然と光る鱗片も、\n鋭い爪先も、垣間見える牙も、",
        "彼が、自分とはどれほど違う存在なのか\nいやおうなしに知らされる。",
        "忘れそうになったけれど、\nフィデスは間違いなく本物の魔獣だ。",
        "例えば彼がひとつ青い炎を吐き出せば、\n魔女といえどわたしは\nたちまち跡形もなく消されてしまうだろう。",
        "その鋭利な煌めきを帯びた瞳と見つめ合って、\nわたしはただ彼の名前を口にして――",
        "その声も、すぐさま\n闇夜に飲み込まれてしまった。",
        "怒声が周りの静寂を震わせた。\nまるでこれはわたしの知るフィデスじゃなく\n全く別の魔獣みたいだ。",
        "彼は完全に思い出したかもしれない…\nその誰も知らない悲しい過去を。\nだから、こうしていきどおっている",
        "そうとわかれば\nさきほどまで胸を占めた恐怖も急速に薄れ、\n代わりに知りたいという気持ちが沸き上がった。",
        "まださっきの激情を残したまま、\n彼の表情はどこか\n諦めきっているように見えた。",
        "一瞬、フィデスの羽ばたく音と\nいつもより荒い息遣いが\nこの静かな空間に満ちた。",
        "金色の野獣の瞳は\n真意を図るように\n真っ直ぐにわたしを見つめている。",
        "その眼差しに負けないように、\nできるだけ強く、彼を見つめ返した。",
        "終わらないような、\n長い沈黙が過ぎ去った。",
        "それは、何かを必死に\n我慢しているような\n苦しくも暖かい声色だった。",
        "大きな翼で何度か羽ばたき、\nフィデスは徐々に地面に降りてきた。",
        "最後の魔法、\nつまりは心を全てほどくということ。",
        "言われるがまま彼に近づき、\nわたしたちはこつんと\nおでこを合わせた。",
        "そもそもドラゴンのおでこがどこなのか\nわたしもよくわからないけれど、\n鱗片の硬い感触が皮膚に触れて、",
        "そこからまるで彼の優しさが\n流れ込んでくるみたいで、\nわたしはひどく安心した。",
        "小さく呪文を唱えると\nフィデスの体は瞬く間に\n眩しい光に包み込まれた。",
        "強い光に視界が眩み、わたしは\n思わず目を強くつむってしまった。",
        "すると、耳殻のすぐそばに\nあの慣れ親しんだ声色が響く。",
        "目を開けて確かめると、\nなぜかドラゴンの姿はもう\nどこにもいなかった。",
        "ドラゴンであることは変わらないが、\nと漠然とした説明をされるが\nわたしの理解はまったく追いつけなかった。",
        "そう口にした彼の強張った表情が\nあまりにも愛おしくて、\n思わず口元を綻ばせた。",
        "何かを隠そうと伸ばされた腕に、\n抵抗もできず抱きしめられる。",
        "わたしを見下ろす\nあの美しい金色の瞳だけは、\n何も変わらない。",
        "もう相手を直視できなくて、\nわたしは顔を覆いながら\n部屋の隅っこで縮こまった。",
        "するとすかさずに大きな影が\n覆いかぶさってきた。",
        "ドン、と逞しい腕によって\n壁と彼の体の隙間に閉じ込められる。",
        "顎に手を添えられ\n強引に向きを変えられる。",
        "魅惑的な金色の瞳が、\n獲物を捕らえるように\n強く絡まってくる。",
        "ドクンドクンと\n鼓動がどんどん加速していく。\n胸が、苦しい。",
        "至近距離で、\nその声は多くの吐息を含んでいた。",
        "不意に、\n彼の整った顔が近づいてきた、\n鼻と鼻の先が触れてしまいそうなくらいに。",
        "頬が熱くて、眩暈がする。\n胸のドキドキが抑えられなくて\n何も考えられない。",
        "熱をたっぷり含んだ息遣いを感じながら\n頷くように、ゆだねるように、\n静かに瞳を閉じた――。"
    },
         new string[]
        {
        "気持ちのいい昼下がり。\n薬草の世話をするために温室に入ると、\n見るからに怪しいダンボールが鎮座していた。",
        "放っておくわけにはいけなくて、\nわたしはおずおずとしゃがんで\n素早くそのダンボール開けた。",
        "ダンボールの中、そこには\nグリフォンの幼獣が\n力なくもたれていたのだ。",
        "いきなり差し込む光にびっくりしたのか、\n大きな金色の瞳が\n怯えながらわたしを見ている。",
        "毛並みは汚れ、ぼさぼさになっているけれど\n小さく丸まった体は愛らしい。",
        "しかし、グリフォンの食べ物とは…\nとそこまで考えていると、\nお兄ちゃんからの手紙を思い出した。",
        "手紙の内容をまとめると――",
        "立ち上がって離れようとすると\nダンボールの中から\n激しい鳴き声がしてきた。",
        "よく見ると、グリフォンの子供は\n箱の中でふわふわの毛並みをぶるぶる\n震わせながら暴れている。",
        "正解！　といわんばかりに金色の瞳は輝いている。",
        "いやがらないことを確認し、\nわたしは両手でできるだけ優しく\nこの子をダンボールから抱き上げた。",
        "すりすりと、首元に頭を摺り寄せてくる姿の\n愛らしさは言葉にできない。",
        "こうして、突如\n一人暮らしだった我が家に\n新たな可愛らしいメンバーが増えた。",
        "数週間後――",
        "元気よく答えると、\nインテゲルは小さな翼をパタパタ羽ばたかせて\n薬草をくちばしに咥えて戻ってきた。",
        "あれからというもの、\nインテゲルの毛並みも回復し\nわたしたちの生活はいたって平和だ。",
        "あの日、お兄ちゃんからの手紙には\n魔獣の記憶を取り戻し\n傷を癒すことについて書かれていたけれど、",
        "今のところ、\nこの子はとても健康そうに見えた。",
        "びっくりしたけれど、\n金色の瞳はひどく真剣で\n彼の思いが伝わってくる。",
        "今すぐ魔法をかけて、\nといわんばかりの勢いで\n彼はわたしのそばをぐるぐる飛び回った。",
        "そうやって\nわたしたちは笑い合った。",
        "あの手紙に記された\n「心をほどく魔法」",
        "この魔法をとなえれば、魔獣は少しずつ\n記憶を取り戻すことができる。",
        "そして記憶と共に\n姿も小さい頃のものから元に戻れるという。\n大した危険性はなさそうだ。",
        "けれどその時のわたしは知らなかった。\n「記憶が戻る」、ということの\n耐えきれないほどの重さを――",
        "それから、数週間が過ぎ去った。",
        "インテゲルは泣きながらわたしの胸に\n頭を埋めた。わたしはよしよしと、\nその白い毛並みを梳いていく。",
        "あの日、魔法を彼に施すと\n一晩にして彼は元の姿を取り戻した。",
        "四肢は伸び、翼もだいぶ立派になった。\nけれども喜びもつかの間\n過去の悲しい記憶が彼に襲い掛かった。",
        "それ以来、彼はよく泣くようになり、\nわたしがそばにいないと\nいつも不安で仕方がないという。",
        "そう言ってはいられない事態が発生したのだ。",
        "濡れた金色の瞳は\nやっとわたしのほうを見てくれた。",
        "ダークトルネード、\nそれはこの魔界の自然災害の一つ。",
        "空気に漂う過剰な魔力が\n強風と絡まり、巨大な竜巻となる。",
        "ダークトルネードの通るところは、\n百年以上の大樹だって\n根こそぎ吹き飛ばされるという。",
        "今はまだ離れているけれど、\n竜巻がたどり着く前に、",
        "ついさっき買ってきた魔法装置で\nうちの周囲にバリアを\n張っておかないといけない",
        "特に深く考えて出た言葉ではない。\nただ最近あぶなっかしい彼を\n心配しているだけ。",
        "けれど――",
        "突然わたしを突き飛ばした彼を見ると、\n翼で激しい気流を作り\n体を浮かせていた。",
        "彼は温室の天井を突き破って\n外に飛び出してしまった。",
        "大きく空いた穴からは風が吹き込んで、\nこれからダークトルネードが来ることを\n思い出させてくれた。",
        "不安で、心臓がバクバク言っている。\n自分言葉で、彼が傷ついていたら\nどうしよう…",
        "このまま彼が二度と戻らなかったら\nどうしよう、\n心の中が不安でいっぱいだ。",
        "気がついたら、わたしも飛び出していた。\n必死にうちの近くを探し回ったけれど、\nあの小さな影はどこにもなかった。",
        "そう遠くないところに、\nもう竜巻が目視できるほど近づいている。",
        "バリアを張るのも間に合わず、\nダークトルネードを囲む爆風が砂塵を巻き起こし\n視界を遮る。",
        "吹っ飛ばされないように辛うじて重力魔法を\n自分にかけたけれど、\n魔力を含んだ風の中ではあまり効果がない。",
        "さらに強い爆風に襲われ、\n両足が宙に浮いた。",
        "木に背中を強打して、\n目の前に星が舞った。\nただし、まだそれで終わりじゃないらしい…",
        "無我夢中に、\nわたしは彼の名前を叫んだ――",
        "ずるずると地面に座り込み、\n体から力が抜ける。",
        "しかし予想した痛みが訪れず、\nわたしが恐る恐る固くつむった目を開くと\nそこには――",
        "愛しいグリフォンの姿があった。",
        "体が震えて、うまくしゃべれない。\nそんなわたしを\n彼は両方の翼で包み込んだ。",
        "安心感が今になって\n涙と共に湧き出る。\nわたしは力任せに彼にしがみついた。",
        "強く、守るように彼の翼がわたしを抱きしめ、\nそのくちばしで\nわたしの頭を優しく撫でた。",
        "もう二度と見失わない――\n彼のぬくもりは何ものにも代えがたい\nわたしの宝物だから。",
        "わたしは片手に包帯を持って\n彼の爪先をグルグル巻いている。",
        "わたしに向かって飛んでくる大きな\n幹を受け止めるため\n彼の前足はひどい打撲傷を負ってしまった。",
        "そう言うと\n彼は甘えるように\n頬にくちばしを摺り寄せてきた。",
        "その銀色の毛先が零れ落ちた涙に触れ、\nわずかに濡れては、\n明かりを反射してキラキラ輝いている。",
        "彼の金色の瞳が真っ直ぐにわたしを捕らえ、\n口に出てしまいそうな言葉を\nやんわりと止めた。",
        "必死に頷くと、\n彼は小さくはにかむように\n目を細めた。",
        "そんな彼を見てしまうと\n胸がぎゅっと締め付けられて、\n彼の言葉に従うほかなかった。",
        "静かに、金色の瞳が閉じる。\n全てを受け止めようとしている。",
        "呪文を唱える。\n途端、彼の体は眩しい光に包まれ\nわたしは目を開いていられなくなった。",
        "光が収束していくと\nそこには――",
        "興奮気味に言いながら\n彼はわたしの胸に飛び込んできて\n強く抱きしめてくれた。",
        "そう言うと彼は手を伸ばし\nまだ腫れている親指で、わたしの頬に残った\n涙の痕を軽くすくった。",
        "人間になったせいで、形が変わった手には\nよれよれになった包帯が垂れ下がっている。\n",
        "それを見て彼はわずかに微笑んで、\n頬を摺り寄せてくる。獣の毛並みとは違う\nサラサラした銀色の髪がちょっとくすぐったい。",
        "ドクンドクンと\n心臓の音をうるさく感じながら聞き返すと\n彼は大きく笑ってみせた。",
        "インテゲルが真っ直ぐにわたしを見つめている。\nその眼差しは、深い愛情に満ちている。",
        "高鳴る心音をごまかしたくて、\nわたしは急いで目を伏せた。",
        "そっと目を上げると\n金色の瞳は下から\nこちらを覗き込んでいる。",
        "膝に置いた手を取られ、\n自分より少し小さなぬくもりに\n掌が包み込まれる。",
        "ないよ、と\nそう言おうとしたとき\n不意に肩に腕を回された。",
        "インテゲルの顔が\nどんどん近づいてきて、\n唇に柔い感触がした。",
        "それは、\n小鳥がついばむような\nとても可愛らしいキスだった。",
        "悪びれもせずに、\n彼は金色の瞳を細めて\n小首を傾げた。",
        "やっと何が起きたのかわかって\n心臓が大きく飛び跳ねる。\n湯気が出てしまいそうなほど顔が熱い。",
        "しばらく反応できなかったせいか、\n少し不安そうな目が\nわたしのほうを伺っている。",
        "そう言うと彼はたちまち破顔して、\nまたわたしを強く抱きしめた。",
        "窓の外、強い風が吹き荒れている。",
        "静かに揺れるランプの光が\nゆらゆらとわたしたちを",
        "優しく照らした――"
 },new string[]  //Narration
        {
            "日もそろそろ落ちる夕刻。\n薬草の世話をするために温室に入ると、\n見るからに怪しいダンボールが鎮座していた。",
            "わたしは手を伸ばし、\nなるべく優しく子犬を抱き上げた。",
            "触れてから気付く、\n子犬はひどく痩せている。",
            "しかも、全身の力が抜けているみたいに\nふにゃふにゃしていて、元気がない。\nとても弱っている。",
            "軽く揺すってみたけれど、\n腕の中の子犬は\nなんの反応も返してくれなかった。",
            "ただ微かに伝わってくる温かい体温が、\nこの子がまだ生きていることを\n教えてくれる。",
            "（でも、お兄ちゃんがいきなり\n子犬を送ってくるなんておかしいわ……\nどういうことなの？）",
            "子犬を慎重にダンボールに戻し、\nわたしは唯一の手掛かり\n――お兄ちゃんからの手紙を広げた。",
            "手紙の内容をまとめると――",
            "紙に書かれた通り食べ物を用意し\n再び温室に戻ってくると、小さなオオカミは\n相変わらず力なく横たわっている。",
            "この子の体調を考えて、\nまずは食べやすいものがいいだろうと\nスープを用意した。",
            "けれども、\nスプーンをその口元に近づかせても\nオオカミはやはり何も反応しない。",
            "そのあと、時間を置き何度も試してみたけれど\nやはりオオカミは何も食べてくれなかった。",
            "仕方なく、わたしとりあえず\nその子に治癒の魔法をかけて、\nしばらく状況を見ることにした。",
            "いつしか、夜のとばりも落ちてきて、\nもうそろそろ就寝する時間だ。",
            "温室の地面には、ダンボールが転倒していた。",
            "ダンボールの中に入れてあげた毛布も\n半分さらけ出していて、\nそのさらに少し前――",
            "白い月明かりに照らされ、\n小さなオオカミは\n力なく地面に伏している。",
            "全身の力を振り絞るように、\nその子は頭を上げて鳴き、\n月に向かって進もうとしている。",
            "けれどその震える足では、\nまともに立ちあげることすら\nできないみたいだ。",
            "その懸命な姿を見ると、\nなんだか鼻の奥がツンと痛んだ。",
            "わたしはすぐに駆け寄って、\nうずくまりその小さな体を抱きしめた。",
            "腕の中で\n小さな体はやはりビクッともしない。",
            "ようやく、腕の中から返事が来た。\n俯いて見ると、真紅の瞳が\n探るような目つきでわたしを見ている。",
            "負けじと見つめ返すと、\nややあってその子はまた目を伏せる。",
            "けれど少し前の\nその周りの全てを拒絶するような\n雰囲気が、少し薄れたふうに感じた。",
            "ほんの小さな声だけれど、\nオオカミはやっと\nわたしに答えてくれた。",
            "あの夜、少しずつスープを舐めとる\nオオカミのやせ細った背中を、\nわたしはいつまでも優しく撫でた。",
            "わたしの手のひらからは、\n柔らかい光が生み出され\nその小さな体にしみこんでいく。",
            "お兄ちゃんによると\nこれは「心をほどく魔法」という。",
            "美しい月光の許で、\nわたしはそう願わずにはいられなかった。",
            "固く閉じられたまぶたの向こう側から、\n朝の清々しい空気を感じる。",
            "けれどそれとは逆に、\n何か、とてつもなく重いものが\n全身に絡んで離してくれない。",
            "苦しげな声を漏らしながら\nわたしが目を開けると、\n視界いっぱいに赤い毛並みが広がっている。",
            "大きな声で彼の名前を呼ぶと、\nこの赤い毛玉がようやく少し動いた。",
            "パタパタと、その立派な\nオオカミの躯体を叩く。",
            "いたって緩慢に、\n赤い毛玉の正体――モルゲンは\nわたしの身体に絡む長い尻尾を緩めた。",
            "わたしが起き上がるのを見て、\n彼はまたゆっくりと体を摺り寄せて\n腰のあたりにピタッとくっついた。",
            "この奇妙な光景が\n最近ではすっかり日常の一部になっている。",
            "どうしてこうなったのか、\n説明するには、時間を数週間前まで\n遡らなければならない。",
            "数週間前――",
            "「心をほどく魔法」を施した次の日、\nあんなに小さかったオオカミは\n突如として成獣の姿を取り戻したのだ。",
            "これも魔法の作用のひとつで、\n魔獣の記憶が戻るにつれ\nその姿もだんだんと元に戻っていくという。",
            "それでも、姿こそ変化したものの\n彼の様子は前とそう変わらなかった。",
            "ただし――\n夜が訪れるたび、彼は必ず\n温室の大きなガラスの前まで行くのだ。",
            "そこで一晩中\nひと時も目をそらさずに\n月を見つめる。",
            "その後ろ姿には、\n言いようのない哀愁と\n底なしの寂しさが漂っている。",
            "何も話してくれない彼に、わたしは\nただ毎晩のように彼に寄り添うように座り\nに月を眺めることしかできなかった。",
            "そばにいるよって、\n少しでも彼に伝えられたらと。",
            "そのままいくつもの夜が過ぎ去り\nついに、満月の日がやってきた――",
            "ガラス越しでも、月の輝きは減らない。\nずっと見ていると、\n吸い込まれてしまいそうになる。",
            "わたしの隣で、\n美しい毛並みのオオカミも一心不乱に\nそのまん丸いあかりを見つめている。",
            "口に出したのは、\nこの美しい風景を見た感動を\n誰かと共有したかったのかもしれない。",
            "だから、彼が声をかけてくれたとき\nわたしは心底驚き、次にじわじわと\n沸き上がる喜びを感じていた。",
            "なんと答えたらいいのかわからず\nただ静かに頷く。",
            "月から目をそらし、\nこっちを見やる真紅の瞳はまるで\n魂の奥底まで見通せるようだ。",
            "長いようで\n短い沈黙が流れていった。",
            "あの満月の夜、\nわたしは初めて彼の名前を知る。",
            "いつか…いつか、\nモルゲンの笑顔が見たい。\nわたしは、そう思うようになった。",
            "あの日から、\n夜に一緒に月を眺めるのは\nほぼ日課のようなものになっていった。",
            "けれどもわたしはよく睡魔に負けるので\nいつも彼が\nわたしを寝室まで送り返してくれる。",
            "それが、いつしか朝になると\nこのあり様である。",
            "この独特な鳴き声は\n手紙を運ぶ鳥の使い魔からのものだ。",
            "起き上がりドアを開けると、\n案の定カラスのような真っ黒い鳥が\n目の前を飛んでいた。",
            "後ろからついてきたモルゲンも、\n使い魔をジーと見ている。",
            "わたしが手を差し出すと使い魔は\n嘴に咥えていたガラスの瓶をおろして、\nまたどこかへ飛んで行った。",
            "素早く封筒を開け、\n黄ばんだ便箋を広げると――",
            "「助けて、やばい」\nと、短くも素直すぎる内容が記されている。",
            "ふざけた文体だけれど\n本当に何かあったらいけない。\n一度この手紙が送られたところに行かないと…",
            "戻るまでいい子にしてね、と\n残り半分の言葉を言えなかった。",
            "それは、大きく吠えたあと\nわたしを見るモルゲンの顔に、\n強い拒絶を感じたからだ。",
            "言うや否や、モルゲンは家具に\nぶつかりながらも窓をぶち破り\n温室のほうへと姿を消した。",
            "わたし一人だけが、\nめちゃくちゃになった部屋の中で\nぽつんと取り残された――",
            "わたしの声だけが、\n温室の中でむなしく響いている。",
            "昼間から幾度この温室を探したけれど\nモルゲンは姿を現してくれなかった。",
            "もしかすると外に出たかもしれないと、\nうちの周りの一通り回ったが、\n彼はどこにもいない。",
            "夜空をのぼる月を見て、\nわたしは慌てて温室に戻った。\nこれが、最後のチャンスなのかもしれない。",
            "心臓が、不安でずっとパクパク言っている。\nわたしは彼を笑わせたかったのに\nどうして、こうなってしまったんだろう。",
            "茂る薬草をかき分けて進むと、\n本当に、本当にいつものように\n彼はガラスの隣に佇んでいた。",
            "何も考えられず、\nわたしは彼に向って走り出した。",
            "けれども、\nまさに彼に触れようとした瞬間――",
            "世界の全てが反転した。",
            "手足を動かして起き上がりたいのに、できない。\n艶やかな毛並みを纏う獣がその力強い四肢で\nわたしの四肢を封じ込んでいるからだ。",
            "いつしか月は雲に隠れ、\n暗闇の中で、彼の真紅の瞳だけが\n妖しくきらめいている。",
            "微かに開かれた口からは\n鋭利な歯がのぞいている。それに\n噛みつかれたら…結果は明白であろう。",
            "荒々しい息遣いだけが\nあたりに充満している。",
            "それでも、わたしには見える。\nその赤い瞳の奥には\n深い、深い悲しみと寂しさが隠されている。",
            "両腕はきつく固定されて動けない。\nそれ以外で、彼を抱きしめる方法を\nわたしは必死に探し出す。",
            "赤い瞳が大きく見開かれ、\n信じられないものを見るように\n瞬きを繰り返した。",
            "次の瞬間、手足の拘束が解かれた。\n自由になった腕で、\nわたしは彼を抱きしめる。",
            "どれほどそうしていたのだろう。\nようやく少し体を離れ、\nぽつぽつと彼の声が零れる。",
            "ポカンとした顔のあと、\n彼が答えを促すように\n鼻先をわたしの頬に摺り寄せた。",
            "雲間から月が再びわずかに顔を出し\n柔らかな光が降り注がれた。",
            "彼が小さく口元を吊り上げる。\nそれはひどくわかりづらい、\n不器用で、真摯な微笑みだった。",
            "静かに頷き、わたしはその頬に手を添えた。\n指先から、まばゆい光が溢れだす。",
            "その光がやがて、彼の体ごとを包み込んだ。",
            "眩しさに目を瞑ってしまうと、\n突然、逞しい腕によって引き寄せられた。",
            "最初に視界に入ったのは、\nもふもふしている獣の耳だった。",
            "その深い赤色で、彼であることを悟る。",
            "たどたどしく言葉を紡ぐ彼に\n胸が甘く締め付けられる。\nわたしは彼の腕にそっと自分の手を重ねた。",
            "ゆっくりと、彼の腕が背中に回り\n気が付けばわたしは\n心地いいぬくもりに包みこまれていた。",
            "それは、毎朝わたしをまどろみから\n揺り起こす温かさと、\n何ら変わりはなかった。",
            "ふと抱きしめられていた腕が解かれ、\nつづけざまに、額に目元に頬に\n羽のような感触が伝わる。",
            "少し遅れて、わたしは\nそれがキスだと悟った。",
            "じゃれ合うような口付けがくすぐったくて、\nでもどこか心地よくて、\n鼓動が一気に加速していく。",
            "やがて彼の唇が肩まで滑り\n触れたところに、ちくっと小さな痛みが伝わる。",
            "くすぐったいような、痛いような、\n奇妙なしびれが、\n何度も背中から脳へ駆け巡る。",
            "何か警鐘のような音が脳裏に響くけど、\nそれを無視するように\nわたしは目の前に広がる夜空に目を向けた。",
            "今夜は、綺麗な下弦の月が\n神秘的な光を放っていて、まるで\n夜空がわたしたちに微笑みかけているみたい。",
            "同じ言葉を贈ろうとしたとき、\n強引に唇を奪われて、わたしは\nなすすべもなく身をゆだねた。"
        }
    };
    private string[][] Majo = new string[][]
    {
          new string[] //Majo
    {
        "「もうー！　お兄ちゃんったら！」",
        "「またこんな落書きの手紙を送って！ \nそれになんか、変なダンボールもあるわ…」",
        "「ん―― \nとりあえずダンボールを開けてみよう！」",
        "「うそ！　ドラゴンの…子供！？」",
        "「た、大変…！　この子、とても弱ってるわ！ \n早く、何かを食べさせないと……」",
        "「うぅ、解読するしかないっか…」",
        "「もうーお兄ちゃんったら、 \nいつも急なんだから！　なになに…」",
        "「ドラゴンの飼育法…？ \nなんか怪しいわね。 \nでも今はそうも言ってられない！」",
        "「ドラゴンちゃん～ね、こっち向いて？」",
        "「お腹すいたでしょう？ \nほら、ここにごはんがあるよ？」",
        "「ご、ごめんね……？」",
        "「きゃっ！」",
        "「わ、わっ！　ごめんね！ \n急に触ろうとして…！　 \nでも、あなたごはんを食べないと…！」",
        "「ごめんね！　 \nごはん、ここに置いておくから…！」",
        "「ね？　出来立てほやほやだよ？」",
        "「心配なら…まずわたしが食べよう！ \nあ―ん、もぐもぐ… \nん――！　おいしい！」",
        "（でも、今はそういう場合じゃないから！）",
        "「ふふっ、美味しかった？ \n全部食べてくれてありがとう！ \n血色が少し良くなったわ」",
        "（あれ、なんかまた \n浮かない顔になった……気がする）",
        "「ど、どうしたの？ \nどこか具合でも悪いの？」",
        "「きゃっ！　冷たい！」",
        "「あっ、傷を舐めてくれてるの？ \nふふっ、ありがとう」",
        "（かわいい……！）",
        "「ふふっ、 \nこれからよろしくね？」",
        "（こうして、 \nわたしとドラゴンの生活が始まった――)",
        "「……あれ？ \nもしかして、フィデス…？」",
        "「やっぱり！　どうしたの？」",
        "（魔界征服の計画とかはよくわからないけど、 \n元に戻すお手伝いならしたい！）",
        "「もちろん！ \nこっちにおいで」",
        "「やっぱり、 \n悪い夢を見る？」",
        "「思い…出したくないの？」",
        "「じゃあ、 \n勇気がでるおまじないを \nかけてあげる」",
        "「そう、これで明日になったら \nもっと勇敢なフィデスになるはずよ」",
        "「大丈夫、 \n明日起きても、 \n明後日になっても……」",
        "「わたしがそばにいるから」",
        "「フィデス――？」",
        "「フィデス――ねぇ、どこにいるの？」",
        "「きゃっ！」",
        "「ふふっ、フィデス \nこんにちは」",
        "（まさかドラゴンのあくびで \nうちの屋根が全て吹き飛ばされと思わなかったわ……）",
        "「ごはんを持ってきたよ！ \n……フィデス？」",
        "「フィデス……？」",
        "「最近、ちょっと元気がない？」",
        "「フィ～デス～～？」",
        "「ただ……？」",
        "「……昔のことを？」",
        "「……よしよし」",
        "「フィデス…？ \nねぇ、どこにいるの？」",
        "「フィデス…あのね、 \nちゃんとお話しましょう…？」",
        "「フィデス、 \nお願い、出てきてよ…！」",
        "「フィデス……？」",
        "「フィデス……」",
        "「フィデス…っ」",
        "「えっ…？」",
        "（も、もしかして…！）",
        "「ねぇ、フィデス… \nどういうこと？」",
        "「フィデス……」",
        "（もう、どうにもならないの…？）",
        "（でも、わたしはまだ…諦めたくない）",
        "「ねぇフィデス、 \nわたしをあなたに預けよう」",
        "「わたしが、あなたのものになるの。 \nそしたらもう、 \nあなたが裏切られることはないよ」",
        "「わかっているわ！ \nあなたのものになって、 \nずっと、あなたの傍にいるの」",
        "「それでも……だめ？」",
        "「……！」",
        "「……っ！」",
        "「……フィ、デス……？」",
        "「……どういう、こと？」",
        "「えっ……？」",
        "「ふふっ」",
        "「……取り消しなんて、しないよ」",
        "「ね、ねぇ…… \n本当に、一緒に、寝るの……？」",
        "「ち、違うの……！ \nただ、その……」",
        "「前に一緒に寝たとき \nフィデスはまだ小さかったでしょう？今はもう、その……」",
        "「それも違う！ \nただ、その、恥ずかしい、よ……っ」",
        "「あっ……」",
        "（なのに、 \nこんなにも嬉しいと \n思ってしまうなんて――）",
        "「……っ！」",
        "（……聞こえてしまったら、 \nどうしよう……）"
    },    new string[]
    {
        "「もうー！　お兄ちゃんったら！」",
        "「またこんな落書きの手紙を送って！ \nそれになんか、変なダンボールもあるわ…」",
        "（それになんか…音がする…？）",
        "「も、もしもし――？」",
        "「えっ」",
        "「かわいい……」",
        "（でも、やっぱりなんか元気がなさそうね… \nお腹でもすかしているのかな？）",
        "「もうーお兄ちゃんったら、 \nいつも急なんだから！　なになに…」",
        "（「グリフォンの飼育法」…？ \nなんかさらに不安になって来たよ…）",
        "「今考えても仕方がないわ！ \nとにかく何か食べ物を…」",
        "「もしかして、一緒に来たいの？」",
        "「じゃあ、抱っこしようか！　いい？」",
        "（なにこの生き物…かわいい…！）",
        "「インテゲル、ちょっと \nそこの棚にある薬草取ってくれる？」",
        "「ありがとう、インテゲル！」",
        "（でも…これが彼の本来の姿じゃないよね… \nやっぱり……）",
        "「ねぇ、インテゲル？」",
        "「インテゲルは、いつか大人になりたい？」",
        "（そ、即答……！)",
        "「えっ」",
        "「実は…大人になる魔法があるの。 \nでもね、つらいこととか \nいっぱい起きちゃうかも」",
        "「それでも \nインテゲルは大人になりたい？」",
        "（うん、まあ… \n大丈夫だよ…ね？）",
        "「じゃあ、これが終わったら \n大きくなれる魔法をかけてあげる！」",
        "「インテ――」",
        "「わっ！　インテゲル！ \nどうしたの？　なんで泣いてるの？」",
        "「ごめんね、インテゲル… \nちょっと買い物に行っていたの。 \nごめんね……」",
        "（できれば… \nずっと彼のそばにいてあげたいけれど…）",
        "「ねぇ、インテゲル \nよく聞いて？」",
        "「今夜、ダークトルネードが来るの」",
        "「だからごめんね？ \nわたしまたちょっとだけ外に \n出なきゃいけないの…」",
        "「でも、あまり時間がないから \n危ないの…インテゲルには \nうちで待ってて欲しいな…？」",
        "「インテゲル…？」",
        "「そんなこと――」",
        "「インテゲル……！」",
        "（どうしよう… \nどうして、こうなったの…？）",
        "（……だめだ… \nこのままじゃ危ない… \nインテゲルを…探さなきゃ…！）",
        "（そんなの、絶対嫌…！）",
        "「インテゲル――！　どこ――！？」",
        "（だめ… \n早くバリアを張らないと…！）",
        "（っ…！ \n黒い砂塵が逆巻いて、襲い掛かってきてる…！）",
        "「きゃっ……！」",
        "「っ…！？」",
        "（う、うそ…！ \nき、木が飛ばされてくる…！）",
        "（ぶ、ぶつかる…！）",
        "「……イ、インテゲル――――」",
        "「い、インテ、ゲル……」",
        "「インテゲル…ご、ごめんね…！」",
        "「ごめんね…！ \nた、助けに来てくれて \nありがとう……！　ごめんね…！」",
        "「泣いて、ない……！」",
        "（必死に頑張っていても、 \n溢れだす涙をなかなかせき止められない）",
        "（だって、わたしを守るために \nけがをさせてしまったんだもん……）",
        "「……ごめんね \nわたしがっ、もっとしっかりしていれば……っ」",
        "「……もちろん」",
        "（そんなこと、絶対ない……！）",
        "「……っ」",
        "「……え？」",
        "「きゃっ！」",
        "「インテゲル、よね？ \n本当に……！？」",
        "「…なあに？」",
        "「……もちろん！」",
        "（そ、そんなに見られると……）",
        "「…ううん、 \nそんなこと……」",
        "「きゃっ」",
        "「い、インテゲル……！？」",
        "（き、キス、された……！）",
        "（でも…… \n嫌な気持ちはこれっぽちもないもの）",
        "（ああ、どんな姿をしていても \nインテゲルは変わらないね）",
        "「ううん、わたしも…… \nインテゲルのことが……好き」",
        "（でもここは…暖かい）",
        "（だって、 \nあなたがここにいるから……インテゲル）"
    },new string[]  //Majo
        {
            "「もうー！　お兄ちゃんったら！」",
            "「またこんな落書きの手紙を送って！ \nそれになんか、変なダンボールもあるわ…」",
            "「ん―― \nとりあえずダンボールを開けてみよう！」",
            "「あれ？ \nこれは――」",
            "（子犬……？）",
            "「えっ」",
            "「ねぇ、あなた \nわたしの声が聞こえる？」",
            "「大変…！ \n早くなにか食べさせないと…！」",
            "「もうーお兄ちゃんったら、 \nいつも急なんだから！　なになに…」",
            "「伝説のオオカミの生態…？ \nえっ、あなたオオカミだったの？ \nううん…今はまずごはんを…！」",
            "「ねぇ、オオカミちゃん \n少しでもいいから \nこのスープを飲んでくれない？」",
            "「食べる力も残っていないのかな… \nどうしよう…」",
            "「あれ？ \nでも、この声はもしかして……！」",
            "（いた……！）",
            "「…っ！」",
            "（どうして、この子は――）",
            "「ねぇ、このままだとあなた \n本当に死んじゃうよ…！」",
            "「わたしたち、今日がはじめましてだよ？ \nだからね…そんなことになって欲しくないの…」",
            "「お願い…… \n少しでも、ごはんを食べて？ \nじゃないと、どこにも行けないのよ…」",
            "「ごはん…食べてくれる？」",
            "「……っ！ \n今すぐ、いっとう美味しいごはんを用意するね！」",
            "（これで、少しでもこの子の \n心に負った傷を癒してあげられたらいいのに…）",
            "「うっ、うう……」",
            "（こ、これは……）",
            "「も、モルゲン――っ！」",
            "「モルゲンー！　もう朝だよー！ \n起きて！　モルゲンが起きないと \nわたしも起きられないからー！」",
            "「ふ――、 \nおはよう、モルゲン」",
            "（いっつもだるそうだし、 \nごはんもあまり積極的に食べてくれない…）",
            "「……満月、とても綺麗だね」",
            "「えっ」",
            "「わたしも…まだよくわからない。 \nでも、あなたの寂しい顔は \nもう見たくないの」",
            "「へ、変…？」",
            "「……ふふっ、そっか」",
            "「たぶん…あなたを \nいとおしいと、思ったからよ」",
            "「えっ？」",
            "「あら、誰なのかな」",
            "「どうも」",
            "「えっと…… \n…またお兄ちゃんから！？」",
            "「もうーお兄ちゃんったら……」",
            "「モルゲン、ごめんね？ \nわたし、ちょっと出かけないといけないかも」",
            "「そう、だから……」",
            "「…っ！」",
            "「も、モルゲン……？」",
            "「えっ…？」",
            "「モルゲン――！ \nモルゲン、どこにいるの……！」",
            "「……モルゲンっ！」",
            "「……え？」",
            "「……も、モルゲン……？」",
            "「ねぇ、モルゲン……」",
            "「教えて…？ \nあなたはなんで \n毎晩のように月を見るの？」",
            "「教えてくれたら、 \nわたしのこと \n好きにしていいから」",
            "「お父さん……？」",
            "（モルゲン……）",
            "「…ねぇ、モルゲン」",
            "「……聞いて？ \nお父さんは、きっとあなたに \n伝えたいことがたくさんあったのよ」",
            "「でも、伝えきれないから、 \nずっとあなたの傍にあるものに \n全部託したんだと思うの」",
            "「ほら『モルゲン』 \nこの名前の意味を考えたこと、ある？」",
            "「『朝』なのよ。 \nモルゲン、あなたの名前は――朝」",
            "「だからもう \nあなたは月の向こう側にいるのよ」",
            "「もう…月を追いかけなくていいの」",
            "「わたしはね…モルゲンの笑顔が見たいの。 \n月を見るときの悲しい顔じゃなくて… \n太陽を見て、笑う顔が見たい」",
            "「だから、わたしはどこにも行かない。 \nずっと…あなたのそばにいたいの」",
            "「…なあに？」",
            "「きゃっ！？」",
            "「どう、して……」",
            "「モルゲン… \nわたしこそ、いきなりあんなこと言いだして \nごめんね……？」",
            "「でも……ふふっ」",
            "「それはね…あなたを \nいとおしいと、思ったからよ」",
            "「ん、ふふっ」",
            "「ん」",
            "（か、噛んだ……っ！）",
            "「……っ！」",
            "（顔が、熱い… \n胸も、痛くて…… \nでも嬉しくて――）",
            "「わ、わたしも――んっ」"
        }
    };
    private string[][] Mobs = new string[][]
    {
         new string[] //Fides
    {
        "「ピ……」",
        "「ピ――っ！」",
        "「ピ――！　ピ――！」",
        "「ピ……、 \nピ……？」",
        "「ピ……」",
        "「ピ、ピ…」",
        "「……" + Username + "」",
        "「その、今日…… \n一緒に寝て…いい？」",
        "「うん…… \nでも、思い出せない」",
        "「ううん、違うと、思う」",
        "「おまじない？」",
        "「――ここだ、" + Username + "」",
        "「……ああ」",
        "「……なんだ」",
        "「そんなことはない。気のせいだ」",
        "「うっ、そんな声で呼ぶな。 \nただ……」",
        "「思い出している…だけだ」",
        "「……ああ」",
        "「…………" + Username + "」",
        "「黙れ！　近寄るな！」",
        "「もうたくさんだ…！ \nどうせお前も俺を裏切るんだろう？」",
        "「あいつらみたいに俺をたぶらかして、 \nいいように利用したいだけだろう！」",
        "「ふん！　とぼけるな！」",
        "「…俺は勇者の招集に応じて \n彼らと共に戦いを勝ち抜いたのに、 \nあっけなく裏切られたんだ！」",
        "「魔王が消えれば、 \n当たり前のようにドラゴンが \n次の標的となるわけだ…」",
        "「そのせいでもう…… \n人間界にも、魔界にも \n俺の帰る場所がない…！」",
        "「……なあ、" + Username + "。 \n教えてくれ…この忌々しい過去を \n消し去る方法を！」",
        "「俺はもう、 \n何も信じられないんだ」",
        "「教えてくれよ…… \nどうすれば、お前をもう一度信じられる…！」",
        "「……は？」",
        "「お、お前……っ \n自分が何を言っているのか \nわかっているんだろうな？」",
        "「お前は…… \nしょうもないやつだな」",
        "「最後の魔法を…かけてくれ」",
        "「" + Username + "……」",
        "「お前のおかげで正真正銘力を取り戻したんだ。\n人の姿に変化するくらい\nどうってことはない」",
        "「わからんのか？ \n俺は人間の姿をしている理由を」",
        "「……もう、 \nさっきの約束を取り消すことは \n許されないぞ」",
        "「な、なぜそこで笑うんだ……！」",
        "「なんだ、 \n何がそんなに不満だと言うんだ」",
        "「もう小さくない俺はいや、と？」",
        "「俺を見ろ。 \nお前はもう俺のものなんだろう？」",
        "「" + Username + "……」",
        "「お前のせいで \n信じてしまったんだ」",
        "「……もう、離さない」",
        "「なあ、" + Username + "…… \n今なら、やっとお前に伝えられる」",
        "「……お前が好きだ」",
        "「これからもずっと、 \nこの命が尽きるまで \n俺の傍に居てくれ」"
    },
            new string[]
    {
        "「みー…みー…」",
        "「み？　み！　み！？」",
        "「みーみ……」",
        "「み……！　み、み…み――！」",
        "「み――！！」",
        "「み――♡」",
        "「みー！　任せて！」",
        "「みー♡」",
        "「えへへ、お姉ちゃんほめられちゃった～」",
        "「み？　なあに、お姉ちゃん」",
        "「なりたいっ！」",
        "「僕はね、 \n大きくなって、お姉ちゃんを守りたい！」",
        "「うん！」",
        "「……！　み♡」",
        "「……お姉ちゃん…っ！」",
        "「お姉ちゃん…どこに行ってたの…！」",
        "「どうして僕をひとりにしたの…っ！」",
        "「…？」",
        "「…えっ？」",
        "「じゃ、じゃあ僕も行く…！」",
        "「いやだっ……！」",
        "「どうして…？」",
        "「お姉ちゃんも、僕が弱いって思ってるの…？ \n弱いから、何もできないって思ってるの…！？」",
        "「僕がほかのみんなより小さかったから！ \n弱かったから…守れなかったんだ……」",
        "「だからもうグリフォンじゃないって… \n誰も僕のそばにいてくれないんだ…！」",
        "「お姉ちゃんなんか……もういや……！」",
        "「――――お姉ちゃん……っ！」",
        "「お姉ちゃん、けがしてない？ \n大丈夫？　ねぇ…！」",
        "「…僕のほうこそ、ごめんなさい… \nお姉ちゃん…ごめんなさい…！」",
        "「ねぇ…お姉ちゃん \nもう泣かないで？」",
        "「ふふっ、お姉ちゃん \nそれはもう何回も聞いたよ？」",
        "「ねぇ、お姉ちゃん \nちょっと、話を聞いてくれる？」",
        "「僕ね \n昔は宝物を守るお仕事をしていたんだ」",
        "「でも、僕は生まれた時から \nみんなみたいに大きくなれなくて…",
        "「あの夜、攻めてきた悪い人たちに勝てなくて… \n宝物を最後まで守れなかったの」",
        "「僕…すごく悔しかったの… \nなんで僕だけができないって…」",
        "「みんなもすっごく怒っちゃって \n僕を追い出したの。 \nほかの仲間にも、バカにされた」",
        "「……もう \n僕は誰の役にも立てないのかな？ \nもういらない子なのかな…」",
        "「ずっと \nそう思ってた」",
        "「…でもね、お姉ちゃん」",
        "「あのダンボールの中でね、 \nお姉ちゃんの声が聞こえたんだ…」",
        "「とても優しい声で…それからもいつも、 \n僕の名前を呼んでくれた。 \nお姉ちゃんの声、僕はとても好きなんだ…」",
        "「この人守りたいって、 \n君が僕を呼ぶたびに、思ったんだ \nだから……」",
        "「ねぇ僕、大切なお姉ちゃんのこと \nちゃんと守れたのかな……？」",
        "「……よかったぁ！」",
        "「お姉ちゃん…… \nもう一度、魔法をかけて？」",
        "「僕、もっと強くなって \nしっかりお姉ちゃんを守れるようになるよ \nだから……」",
        "「僕、全部ぜんぶ、思い出したいんだ」",
        "「お、お姉ちゃん……！　 \n見て、僕…人間の姿に……！」",
        "「うん！　僕だよ！ \nえへへ、お姉ちゃんとずっと一緒にいたい、 \nそう願ったから、人間の姿になれたのかな？」",
        "「ねぇ、お姉ちゃん……」",
        "「これからも…… \nずっとずっと、ず――っと \n傍に居させて？」",
        "「ねぇ…… \nこっち向いて？」",
        "「僕ね、ここに来て \n本当に嬉しいんだ……」",
        "「これからも、一緒に買い物に行って、 \n新しい魔法探して、美味しいごはんを食べて… \nお姉ちゃんと色んなことを一緒にしたい」",
        "「朝起きて最初に、夜眠りつく前に、 \n僕は一番近くに……ずっと \nお姉ちゃんの声を聞いていたい」",
        "「今だって、 \nいっぱい話したいことがあるし…… \n朝までこうしていたい」",
        "「こんな僕じゃ、ダメ……？」",
        "「……ん」",
        "「えへへ、 \n奪っちゃった」",
        "「"+Username+"ちゃん、 \n……好き」",
        "「……いや、だった？」",
        "「お姉ちゃん、大好きっ！」"
    },new string[]  //Wolf
        {
            "「………………」",
            "「オ――――ン」",
            "「オ――――ン」",
            "「クゥ…」",
            "「クゥ……」",
            "「クゥ……」",
            "「……クゥフ」",
            "「……あんた」",
            "「おれが、ここで目覚めてから… \n月を見るときはずっと… \nあんたがそばにいた…」",
            "「……なんでだ」",
            "「…なんであんたは… \nそばにいてくれんだ…？」",
            "「あんた…すごく、変だ……」",
            "「変だ。 \nんなこと…初めて言われたんだ…」",
            "「なんで、笑うんだ……？」",
            "「…………モルゲン」",
            "「……おれの、名前だ」",
            "「…出かける…？」",
            "「結局…結局あんたも… \nいっちまうのかよ……？」",
            "「あんたも、おれを置いて… \nいなくなっちまうのかよ…！」",
            "「……！」",
            "「おれは、ずっと…… \n親父を探してたんだ……」",
            "「親父は \n月の向こうで待ってるとかつってさ \nいきなり……いなくなったんだ」",
            "「おれ、それからずっと \n月を追っかけて、追っかけて… \nけどどうしても、追い付かねぇんだ…！」",
            "「だんだん足が動かなくなっちまって \n月が、遠くて… \nもう、疲れちまったんだよ…」",
            "「あんたも…あんたも \n親父みてぇにいなくなるんなら… \nいっそ…この首筋をひきちぎってさ…」",
            "「おれも、すぐにイくからよ… \nなあ…一緒に消えちまって… \nそんでずうっと、一緒にいようよ……」",
            "「親父、が……？」",
            "「なあ……」",
            "「もう一度さ…魔法をかけてよ」",
            "「今度こそ、おれは全てを思い出すよ。 \nそしたら…今度は \nあんたと一緒に太陽を見に行きてぇ」",
            "「わかんねぇ…… \nでもずっとあんたと一緒にいてぇ… \nそう、思ったら」",
            "「初めてだったんだ… \n誰かが月を一緒に見てくれんのが…」",
            "「不思議なもんだな…それだけで… \nまた生きてみようと…生きていけると \n思っちまうんだ……」",
            "「けどよ…あんたが家から出るつったとき… \nまた…今晩は一人であの月を \n見なきゃいけねぇのかよと思って…」",
            "「それがさ、どうしても \n耐えられなかったんだよ」",
            "「……ごめん…」",
            "「なんで、笑うんだ……？」",
            "「"+Username+"……」",
            "「あんた…やわらけぇな…」",
            "「……んっ」",
            "「……"+Username+"」",
            "「あの日 \nあんたに拾われてからずっと…… \nもう、おれの月は――あんただ」",
            "「あんたが、好きだ……」",
            "「もう \nどこにも行かせねぇよ」",
            "「おれだけの、"+Username+"――」"
        }
    };

    private string[][] Mao = new string[][]
    {
         new string[] // Mao
    {
        "「我が妹よ――！ \nこの魔界で最強の魔王になることこそが \n俺様の宿願！　フハハハ！」",
        "「そのためにも \n俺様の軍隊を作り上げなければならない！ \nだがしか――しっ！」",
        "「この魔界では、 \n深刻な人材不足に直面しているのだ！ \nそこで！　天才たる俺様は考えた！」",
        "「――魔獣の落ちこぼれを拾って、 \n立派な魔獣に育てようじゃないか！　フハハハ！」",
        "「すると、強大な魔獣軍団ができるじゃないか！ \n俺様は、その重大な任務をお前に任せたい！」",
        "「P.S　必要な資料も \n送ってやったぞ！　礼は俺様の好物で良い！ \n……ピーマンだけはもう勘弁してくれ！」"
    },  new string[]
    {
        "「我が妹よ――！ \nこの魔界で最強の魔王になることこそが \n俺様の宿願！　フハハハ！」",
        "「そのためにも \n俺様の軍隊を作り上げなければならない！ \nだがしか――しっ！」",
        "「この魔界では、 \n深刻な人材不足に直面しているのだ！ \nそこで！　天才たる俺様は考えた！」",
        "「――魔獣の落ちこぼれを拾って、 \n立派な魔獣に育てようじゃないか！　フハハハ！」",
        "「すると、強大な魔獣軍団ができるじゃないか！ \n俺様は、その重大な任務をお前に任せたい！」",
        "「P.S　必要な資料も \n送ってやったぞ！　礼は俺様の好物で良い！ \n……ピーマンだけはもう勘弁してくれ！」"
    }, new string[]  //Mao
        {
            "「我が妹よ――！ \nこの魔界で最強の魔王になることこそが \n俺様の宿願！　フハハハ！」",
            "「そのためにも \n俺様の軍隊を作り上げなければならない！ \nだがしか――しっ！」",
            "「この魔界では、 \n深刻な人材不足に直面しているのだ！ \nそこで！　天才たる俺様は考えた！」",
            "「――魔獣の落ちこぼれを拾って、 \n立派な魔獣に育てようじゃないか！　フハハハ！」",
            "「すると、強大な魔獣軍団ができるじゃないか！ \n俺様は、その重大な任務をお前に任せたい！」",
            "「P.S　必要な資料も \n送ってやったぞ！　礼は俺様の好物で良い！ \n……ピーマンだけはもう勘弁してくれ！」"
        }
    };
}


