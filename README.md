# 김재성 강사님 특강 - 구글 스프레드시트를 웹페이지 경로만으로 다운받는 기술.

## 주요 코드
### SheetData.cs
- URL 구조를 짜둔 후 프로퍼티를 통해 시트 ID, 포맷을 입력할 수 있게 한다.
- UnityWebRequest를 이용하여 데이터를 요청한다.
- 요청에 성공하면 텍스트 형태로 불러오는데 이를 Split하여 배열로 저장해둔다.

### MonsterDataSO.cs
- 몬스터 정보를 담을 수 있는 스크립터블 오브젝트.

### DataManager.cs
- SheetData를 통해 받은 데이터 줄들을 가공하여 MonsterDataSO에 저장.
