using System;
using System.Collections;
using System.Collections.Generic;
using MiniMission;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NephilimShipComponent : MonoBehaviour
{
    private Dictionary<string, string> _textBase;
    [SerializeField] private GameObject _textPanel;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private Button _labButton, _operationButton, _cockpitButton, _generatorButton, _diningroomButton, _bedroomButton;
    [SerializeField] private Camera _camera;
    [SerializeField] private HeadView _view, _view2;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _textBase = new Dictionary<string, string>();
        _textBase.Add("laboratory", "Скользнув взглядом по помещению, ты сразу отмечаешь странный, будто неживой поток освещения, который его заливает. " +
                                    "Пространство этого места наполнено каким-то мертвенным светом, который чужероден любой земной форме жизни. " +
                                    "Когда ты внимательно осматриваешь это помещение, замечаешь, что оно явно служит исследовательским целям - " +
                                    "странные инструменты, флуоресцирующие жидкости, в некоторых можно разглядеть едва различимые силуэты антропоморфных существ. " +
                                    "Выступающие из стен сегменты исчезающие и проступающие сквозь саму поверхность схем вновь инфоформы, " +
                                    "заполненные диаграммами, схемами и символами, в том числе, анатомическим строением маури." +
                                    "\n \nКто бы ни явился в солнечную систему незваным гостем, раньше он имел дело с маури - ловил их, " +
                                    "изучал и препарировал. И не только их - множество других рас, незнакомых и странных, стали трофеями. " +
                                    "Как, возможно, станут и люди.");
        _textBase.Add("operational", "Это помещение наполнено мертвенным и странным светом, его формы неясны и навевают тоску, которая ощутима и словно " +
                                     "находится в нескольких метрах от тебя. Стены и пол идеально гладкие, смыкаются над головой, светятся будто изнутри. " +
                                     "Когда то тут явно был операционный стол, чья холодная поверхность пугала своей стерильностью и обманчивой чистотой. " +
                                     "А над ним нависают разнообразное по форме и размерам оборудование и совершенно невообразимые инструменты, " +
                                     "о предназначении которых не сложно догадаться, но трудно представить в действии.  Пол будто скрипит, " +
                                     "и этот скрип как звук когтя по стеклу неприятно отзывается в сердце и покрываешь тело мурашками. " +
                                     "\n \nЗдесь происходили ужасные вещи, которые никто и никогда не хотел бы знать. Сама суть инструментария " +
                                     "подсказывает, что он создан умом, категорически отличным от человеческого. Не признающим близкой морали и, " +
                                     "скорее всего, не имеющим ничего похожего на привычную эмпатию.");
        _textBase.Add("generator","Помещение будто заполнено каким-то проникающим до костей гулом, который невозможно услышать, но ощущается он так, " +
                                  "будто само пространство здесь искажено, напряжено до предела и готово разорваться вместе с твоим телом. " +
                                  "Нахождение здесь причиняет тебе почти физическую боль. Воздух крайне наэлектризован, хотя что является его" +
                                  " источником, понять сразу не удается. Не замеченные сразу, и словно вросшие в перебоки, от пола и потолка над " +
                                  "и под шаром в стороны и далее в стены уходят многочисленные толстые кабели. Мрачный свет, исходящий от него, " +
                                  "колеблется и вибрирует вместе с окружающим пространством. " +
                                  "\n \nСамо пространство и время искажаются здесь. Законы физики оказались попраны, и явно в ужасе отступили, " +
                                  "дав возможность покорителям звезд пронзать материю космоса, перемещаясь между звездными системами.");
        _textBase.Add("bedroom","Помещение, размеры которого ты не можешь описать корректно, удивительно пустое и удушающее. Если бы у находящегося " +
                                "здесь была клаустрофобия, тут она развилась бы на максимум. Непонятно что вызывало это чувство, но стены будто " +
                                "сужались и давили, с потолка капала слизь, а пол хотел втянуть тебя в себя. Всё такое вязкое и тягучее, что это " +
                                "прочти крохотное пространство пройти оказывается сложнее всего. Место больше похожее на спальню. Спальню для вечного сна. " +
                                "\n \nТе, кто обитает здесь, не гуманоиды и близко не стоят к ним. Судя по всему, ближе всего они к аморфной субстанции, " +
                                "принимающей необходимую форму по мере необходимости. Что-то знакомое.");
        _textBase.Add("cockpit","Это самое странное место из всех, не смотря на всё увиденное ранее. Здесь пропадает чувство собственного я. " +
                                "Не ты управляешь местом, а место будто контролирует тебя или по крайне мере тебе так начинает казаться. " +
                                "Непонятные всплывающие то тут то там окна, отдаленное похожие на знакомые вирт-окна навигаторов, сигналы и маячки, " +
                                "но не ты считываешь с них информацию, а они требуют от тебя действий. “Подойди! Сделай! Ты должен! Работа стоит!” " +
                                "- будто кричит твоё подсознание, и меж тем всё внутри сопротивляется этому противоестественному вмешательству в " +
                                "разум. Это не похоже на партнерство или симбиоз с машиной, или кем или чем является этот корабль, а скорее на " +
                                "захватничество, порабощение более слабого разума в своих корыстных целях, и то что он заставляет тебя делать " +
                                "тебе совершенно не нравится." +
                                "\n \nВсе вычислительные инструменты и приборы здесь являются отдельной жизнью, и отдельным существом. Жизнь, " +
                                "построенная на кремнии и цинке. Особое внимание привлекает то, что можно было бы назвать системой курсоуказания. " +
                                "Внутри объекта странной формы причудливо изгибается серая, меняющая форму слизь. Очень похожая на… Ариэлянскую " +
                                "ксеножизнь. Может ли быть так, что когда-то разведчик этой расы захватчиков разбился на ариэле, и одна из " +
                                "корабельных систем сумела выжить и занять астероид, не зная, куда себя применить?");
        _textBase.Add("diningroom","Здесь как не кстати вспомнились то ли виденные на видеозаписях ролики, то ли где то когда то вживую воспоминания " +
                                   "о мясном цехе, с подвешенными к потолку тушами непонятного животного происхождения, смрадом, мухами, и " +
                                   "пронизывающим холодом. Вот только туш здесь нет. Но тот ареол который они вокруг себя создают наводит на мысль," +
                                   " что их просто не видно. Кажется загляни за угол и они складированны там в большом количестве. Или может в " +
                                   "стенах есть потайные ящики? Как в крематории? Проникшая даже сюда иноземная мошкара вьется перед глазами надеясь " +
                                   "проникнуть за защитное стекло, бьется об него, оставляя размазанные мерзкие пятна  и мешая обзору. " +
                                   "Запах стоит в комнате настолько сильный, что его даже видно, как рябь сотрясаемого воздуха поднимающегося вверх. " +
                                   "Насколько он сильный можно только догадываться, и возможно ли его выдержать без хим защиты - сильно сомневаюсь." +
                                   "\n \nСудя по всему, для питания экипажу этого судна подходят углеводные составляющие, обогащенные металлами и " +
                                   "кремнием. И, кажется, им все равно, что употреблять в пищу. Или кого.");
    }

    public void GetText(string key)
    {
        if (!_textPanel.activeSelf)
        {
            _textPanel.SetActive(true);
        }
        _textField.text = _textBase[key];
    }
    
    public void CloseTextPanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
            _textPanel.SetActive(false);
            _view.isActive = true;
            _view2.isActive = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        var myRay = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(myRay, out var hit, 4))
            {
                switch (hit.collider.gameObject.name)
                    {
                        case "laboratory":
                            if (hit.collider.gameObject.transform.GetComponentInChildren<Light>(true).isActiveAndEnabled)
                            {
                                GetText("laboratory");
                                _labButton.gameObject.SetActive(true);
                                hit.collider.gameObject.transform.GetComponentInChildren<Light>().gameObject
                                    .SetActive(false);
                            }

                            break;
                        case "operational":
                            if (hit.collider.gameObject.transform.GetComponentInChildren<Light>(true).isActiveAndEnabled)
                            {
                                GetText("operational");
                                _operationButton.gameObject.SetActive(true);
                                hit.collider.gameObject.transform.GetComponentInChildren<Light>().gameObject
                                    .SetActive(false);
                            }

                            break;
                        case "cockpit":
                            if (hit.collider.gameObject.transform.GetComponentInChildren<Light>(true).isActiveAndEnabled)
                            {
                                GetText("cockpit");
                                _cockpitButton.gameObject.SetActive(true);
                                hit.collider.gameObject.transform.GetComponentInChildren<Light>().gameObject
                                    .SetActive(false);
                            }

                            break;
                        case "bedroom":
                            if (hit.collider.gameObject.transform.GetComponentInChildren<Light>(true).isActiveAndEnabled)
                            {
                                GetText("bedroom");
                                _bedroomButton.gameObject.SetActive(true);
                                hit.collider.gameObject.transform.GetComponentInChildren<Light>().gameObject
                                    .SetActive(false);
                            }

                            break;
                        case "diningroom":
                            if (hit.collider.gameObject.transform.GetComponentInChildren<Light>(true).isActiveAndEnabled)
                            {
                                GetText("diningroom");
                                _diningroomButton.gameObject.SetActive(true);
                                hit.collider.gameObject.transform.GetComponentInChildren<Light>().gameObject
                                    .SetActive(false);
                            }

                            break;
                        case "generator":
                            if (hit.collider.gameObject.transform.GetComponentInChildren<Light>(true).isActiveAndEnabled)
                            {
                                GetText("generator");
                                _generatorButton.gameObject.SetActive(true);
                                hit.collider.gameObject.transform.GetComponentInChildren<Light>().gameObject
                                    .SetActive(false);
                            }

                            break;
                    }
            }
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.Confined;
            _view.isActive = false;
            _view2.isActive = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _view.isActive = true;
            _view2.isActive = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (_textPanel.activeSelf)
        {
            _view.isActive = false;
            _view2.isActive = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
